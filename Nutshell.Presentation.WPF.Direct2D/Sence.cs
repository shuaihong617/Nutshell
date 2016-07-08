using System;
using Microsoft.WindowsAPICodePack.DirectX;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.Direct3D;
using Microsoft.WindowsAPICodePack.DirectX.Direct3D10;
using Microsoft.WindowsAPICodePack.DirectX.Graphics;

namespace Nutshell.Presentation.Direct2D1
{
        /// <summary>Represents a Direct2D drawing.</summary>
        public abstract class Sence : IdentityObject
        {
                private readonly D2DFactory _factory;
                private D3DDevice _device;
                private RenderTarget _renderTarget;
                private Texture2D _texture;

                /// <summary>
                ///         Initializes a new instance of the Scene class.
                /// </summary>
                protected Sence()
                {
                        // We'll create a multi-threaded one to make sure it plays nicely with WPF
                        _factory = D2DFactory.CreateFactory(D2DFactoryType.Multithreaded);
                }

                /// <summary>Gets the surface this instance draws to.</summary>
                /// <exception cref="ObjectDisposedException">
                ///         <see cref="Dispose()" /> has been called on this instance.
                /// </exception>
                public Texture2D Texture
                {
                        get
                        {
                                MustNotDisposed();
                                return _texture;
                        }
                }

                /// <summary>
                ///         Gets the <see cref="Microsoft.WindowsAPICodePack.DirectX.Direct2D1.D2DFactory" /> used to create the resources.
                /// </summary>
                protected D2DFactory Factory
                {
                        get { return _factory; }
                }

                /// <summary>
                ///         Finalizes an instance of the Scene class.
                /// </summary>
                ~Sence()
                {
                        Dispose(false);
                }

                /// <summary>
                ///         Raised when the content of the Scene has changed.
                /// </summary>
                public event EventHandler Updated;

                /// <summary>
                ///         Creates a DirectX 10 device and related device specific resources.
                /// </summary>
                /// <exception cref="InvalidOperationException">
                ///         A previous call to CreateResources has not been followed by a call to
                ///         <see cref="FreeResources" />.
                /// </exception>
                /// <exception cref="ObjectDisposedException">
                ///         <see cref="Dispose()" /> has been called on this instance.
                /// </exception>
                /// <exception cref="Microsoft.WindowsAPICodePack.DirectX.DirectXException">
                ///         Unable to create a DirectX 10 device or an error occured creating
                ///         device dependent resources.
                /// </exception>
                public void CreateResources()
                {
                        MustNotDisposed();
                        if (_device != null)
                        {
                                throw new InvalidOperationException(
                                        "A previous call to CreateResources has not been followed by a call to FreeResources.");
                        }

                        // Try to create a hardware device first and fall back to a
                        // software (WARP doens't let us share resources)
                        D3DDevice1 device1 = TryCreateDevice1(DriverType.Hardware);
                        if (device1 == null)
                        {
                                device1 = TryCreateDevice1(DriverType.Software);
                                if (device1 == null)
                                {
                                        throw new DirectXException("Unable to create a DirectX 10 device.");
                                }
                        }
                        _device = device1.QueryInterface<D3DDevice>();
                        device1.Dispose();
                }

                /// <summary>
                ///         Releases the DirectX device and any device dependent resources.
                /// </summary>
                /// <remarks>
                ///         This method is safe to be called even if the instance has been disposed.
                /// </remarks>
                public void FreeResources()
                {
                        OnFreeResources();

                        SafeDispose(ref _texture);
                        SafeDispose(ref _renderTarget);
                        SafeDispose(ref _device);
                }

                /// <summary>
                ///         Causes the scene to redraw its contents.
                /// </summary>
                /// <exception cref="InvalidOperationException">
                ///         <see cref="Resize" /> has not been called.
                /// </exception>
                /// <exception cref="ObjectDisposedException">
                ///         <see cref="Dispose()" /> has been called on this instance.
                /// </exception>
                public void Render()
                {
                        MustNotDisposed();
                        _renderTarget.MustNotNull("Resize方法未调用");

                        Render(_renderTarget);
                        
                        _device.Flush();

                        OnUpdated();
                }

                /// <summary>Resizes the scene.</summary>
                /// <param name="width">The new width for the scene.</param>
                /// <param name="height">The new height for the scene.</param>
                /// <exception cref="ArgumentOutOfRangeException">
                ///         width/height is less than zero.
                /// </exception>
                /// <exception cref="InvalidOperationException">
                ///         <see cref="CreateResources" /> has not been called.
                /// </exception>
                /// <exception cref="ObjectDisposedException">
                ///         <see cref="Dispose()" /> has been called on this instance.
                /// </exception>
                /// <exception cref="Microsoft.WindowsAPICodePack.DirectX.DirectXException">
                ///         An error occured creating device dependent resources.
                /// </exception>
                public void Resize(int width, int height)
                {
                        MustNotDisposed();
                        width.MustGreaterThan(0);
                        height.MustGreaterThan(0);
                        _device.MustNotNull("CreateResources方法未调用");
                        
                        // Recreate the render target
                        CreateTexture(width, height);
                        using (var surface = _texture.QueryInterface<Surface>())
                        {
                                CreateRenderTarget(surface);
                        }

                        // Resize our viewport
                        var viewport = new Viewport();
                        viewport.Height = (uint) height;
                        viewport.MaxDepth = 1;
                        viewport.MinDepth = 0;
                        viewport.TopLeftX = 0;
                        viewport.TopLeftY = 0;
                        viewport.Width = (uint) width;
                        _device.RS.Viewports = new[] {viewport};

                        // Destroy and recreate any dependent resources declared in a
                        // derived class only (i.e don't destroy our resources).
                        OnFreeResources();
                        OnCreateResources(_renderTarget);
                }


                protected override void DisposeManagedResources()
                {
                        FreeResources();

                        _factory.Dispose();
                        
                        base.DisposeManagedResources();
                }


                /// <summary>
                ///         When overriden in a derived class, creates device dependent resources.
                /// </summary>
                protected virtual void OnCreateResources(RenderTarget target)
                {
                }

                /// <summary>
                ///         When overriden in a deriven class, releases device dependent resources.
                /// </summary>
                protected virtual void OnFreeResources()
                {
                }

                /// <summary>
                ///         When overriden in a derived class, renders the Direct2D content.
                /// </summary>
                protected abstract void Render(RenderTarget target);

                private static D3DDevice1 TryCreateDevice1(DriverType type)
                {
                        // We'll try to create the device that supports any of these feature levels
                        FeatureLevel[] levels =
                        {
                                FeatureLevel.Ten,
                                FeatureLevel.NinePointThree,
                                FeatureLevel.NinePointTwo,
                                FeatureLevel.NinePointOne
                        };

                        foreach (FeatureLevel level in levels)
                        {
                                try
                                {
                                        return D3DDevice1.CreateDevice1(null, type, null,
                                                CreateDeviceOptions.SupportBgra, level);
                                }
                                catch (ArgumentException) // E_INVALIDARG
                                {
                                }
                                catch (OutOfMemoryException) // E_OUTOFMEMORY
                                {
                                }
                                catch (DirectXException) // D3DERR_INVALIDCALL or E_FAIL
                                {
                                }
                        }
                        return null; // We failed to create a device at any required feature level
                }

                private void CreateRenderTarget(Surface surface)
                {
                        // Create a D2D render target which can draw into our offscreen D3D
                        // surface. D2D uses device independant units, like WPF, at 96/inch
                        var properties = new RenderTargetProperties();
                        properties.DpiX = 96;
                        properties.DpiY = 96;
                        properties.MinLevel = FeatureLevel.Default;
                        properties.PixelFormat = new PixelFormat(Format.Unknown, AlphaMode.Premultiplied);
                        properties.RenderTargetType = RenderTargetType.Default;
                        properties.Usage = RenderTargetUsages.None;

                        // Assign result to temporary variable in case CreateGraphicsSurfaceRenderTarget throws
                        RenderTarget target = _factory.CreateGraphicsSurfaceRenderTarget(surface, properties);

                        if (_renderTarget != null)
                        {
                                _renderTarget.Dispose();
                        }
                        _renderTarget = target;
                }

                private void CreateTexture(int width, int height)
                {
                        var description = new Texture2DDescription();
                        description.ArraySize = 1;
                        description.BindingOptions = BindingOptions.RenderTarget | BindingOptions.ShaderResource;
                        description.CpuAccessOptions = CpuAccessOptions.None;
                        description.Format = Format.B8G8R8A8UNorm;
                        description.MipLevels = 1;
                        description.MiscellaneousResourceOptions = MiscellaneousResourceOptions.Shared;
                        description.SampleDescription = new SampleDescription(1, 0);
                        description.Usage = Usage.Default;

                        description.Height = (uint) height;
                        description.Width = (uint) width;

                        // Assign result to temporary variable in case CreateTexture2D throws
                        Texture2D texture = _device.CreateTexture2D(description);
                        if (_texture != null)
                        {
                                _texture.Dispose();
                        }
                        _texture = texture;
                }

                private void OnUpdated()
                {
                        var callback = this.Updated;
                        if (callback != null)
                        {
                                callback(this, EventArgs.Empty);
                        }
                }
        }
}