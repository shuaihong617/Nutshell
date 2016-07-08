using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Nutshell.Presentation.Direct2D1
{
    /// <summary>Hosts a <see cref="Sence"/> instance.</summary>
    public sealed class Direct2DImage : FrameworkElement
    {
        /// <summary>
        /// Identifies the <see cref="Sence"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SenceProperty =
            DependencyProperty.Register("Sence", typeof(Sence), typeof(Direct2DImage), new UIPropertyMetadata(SceneChangedCallback));

        // To prevent lots or resizing, we're going to use a timer to resize the
        // image after a set interval. We can then reset the timer if we recieve
        // another request to resize, helping performance. When resizing, the
        // Image control will scale the old contents for us, which will be blurry
        // but it's only for a little time so should be unnoticeable.
        private static readonly TimeSpan ResizeInterval = TimeSpan.FromMilliseconds(100);
        private readonly DispatcherTimer _resizeTimer;

        private readonly Image image;
        private readonly D3D10Image _imageSource;
        private bool _isDirty;

        /// <summary>
        /// Initializes a new instance of the Direct2DControl class.
        /// </summary>
        public Direct2DImage()
        {
            this._resizeTimer = new DispatcherTimer();
            this._resizeTimer.Interval = ResizeInterval;
            this._resizeTimer.Tick += this.ResizeTimerTick;

            this._imageSource = new D3D10Image();
            this._imageSource.IsFrontBufferAvailableChanged += OnIsFrontBufferAvailableChanged;

            this.image = new Image();
            this.image.Stretch = Stretch.Fill; // We set this because our resizing isn't immediate
            this.image.Source = this._imageSource;
            this.AddVisualChild(this.image);

            // To greatly reduce flickering we're only going to AddDirtyRect
            // when WPF is rendering.
            CompositionTarget.Rendering += this.CompositionTargetRendering;
        }

        /// <summary>
        /// Gets or sets the <see cref="Sence"/> object displayed
        /// by this control.
        /// </summary>
        /// <remarks>
        /// The caller is resposible for the lifetime management of the Scene.
        /// </remarks>
        public Sence Sence
        {
            get { return (Sence)this.GetValue(SenceProperty); }
            set { this.SetValue(SenceProperty, value); }
        }

        /// <summary>
        /// Gets the number of visual child elements within this element.
        /// </summary>
        /// <remarks>
        /// This will always return 1 as this control hosts a single
        /// Image control.
        /// </remarks>
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        /// <summary>Arranges and sizes the child Image control.</summary>
        /// <param name="finalSize">The size used to arrange the control.</param>
        /// <returns>The size of the control.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Size size = base.ArrangeOverride(finalSize);
            image.Arrange(new Rect(0, 0, size.Width, size.Height));
            return size;
        }

        /// <summary>Returns the child Image control.</summary>
        /// <param name="index">
        /// The zero-based index of the requested child element in the collection.
        /// </param>
        /// <returns>The child Image control.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// index is less than zero or greater than VisualChildrenCount.
        /// </exception>
        protected override Visual GetVisualChild(int index)
        {
            if (index != 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return this.image;
        }

        /// <summary>
        /// Updates the UIElement.DesiredSize of the child Image control.
        /// </summary>
        /// <param name="availableSize">The size that the control should not exceed.</param>
        /// <returns>The child Image's desired size.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            this.image.Measure(availableSize);
            return this.image.DesiredSize;
        }

        /// <summary>
        /// Participates in rendering operations that are directed by the layout system.
        /// </summary>
        /// <param name="sizeInfo">
        /// The packaged parameters, which includes old and new sizes, and which
        /// dimension actually changes.
        /// </param>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (this.Sence != null)
            {
                // Signal to resize
                this._resizeTimer.Start();
            }
        }

        private static void SceneChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (Direct2DImage)d;

            // Unsubscribe from the old scene first
            if (e.OldValue != null)
            {
                ((Sence)e.OldValue).Updated -= instance.SceneUpdated;
            }

            instance.OnSceneChanged();

            // Now subscribe to the events once all the resources have been created
            if (e.NewValue != null)
            {
                ((Sence)e.NewValue).Updated += instance.SceneUpdated;
            }
        }

        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            if (this._isDirty)
            {
                this._isDirty = false;
                if (this._imageSource.IsFrontBufferAvailable)
                {
                    this._imageSource.Lock();
                    this._imageSource.AddDirtyRect(new Int32Rect(0, 0, this._imageSource.PixelWidth, this._imageSource.PixelHeight));
                    this._imageSource.Unlock();
                }
            }
        }

        private void OnIsFrontBufferAvailableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Sence != null)
            {
                if (this._imageSource.IsFrontBufferAvailable)
                {
                    this.OnSceneChanged(); // Recreate the resources
                }
                else
                {
                    this.Sence.FreeResources();
                }
            }
        }

        private void OnSceneChanged()
        {
            this._imageSource.Lock();
            try
            {
                if (this.Sence != null)
                {
                    this.Sence.CreateResources();

                    // Resize to the size of this control, if we have a size
                    int width = Math.Max(1, (int)this.ActualWidth);
                    int height = Math.Max(1, (int)this.ActualHeight);
                    this.Sence.Resize(width, height);

                    this._imageSource.SetBackBuffer(this.Sence.Texture);
                    this.Sence.Render();
                }
                else
                {
                    this._imageSource.SetBackBuffer(null);
                }
            }
            finally
            {
                this._imageSource.Unlock();
            }
        }

        private void ResizeTimerTick(object sender, EventArgs e)
        {
            this._resizeTimer.Stop(); // Only call this method once
            if (this.Sence != null)
            {
                // Check we don't resize too small
                int width = Math.Max(1, (int)this.ActualWidth);
                int height = Math.Max(1, (int)this.ActualHeight);
                this.Sence.Resize(width, height);

                this._imageSource.Lock();
                this._imageSource.SetBackBuffer(this.Sence.Texture);
                this._imageSource.Unlock();

                this.Sence.Render();
            }
        }

        private void SceneUpdated(object sender, EventArgs e)
        {
            this._isDirty = true;
        }
    }
}
