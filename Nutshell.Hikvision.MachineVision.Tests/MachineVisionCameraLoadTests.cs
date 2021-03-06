﻿using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using Nutshell.Hikvision.MachineVision.Models;
using Nutshell.Hikvision.MachineVision.SDK;
using Nutshell.Storaging.Xml;

namespace Nutshell.Hikvision.MachineVision.Tests
{
        [TestClass()]
        public class MachineVisionCameraLoadTests
        {
                [TestMethod()]
                public void LoadTest()
                {
                        var camera = XmlStorager<MachineVisionCameraDevice, MachineVisionCameraDeviceModel>.Instance.Load(@"测试文件/Camera.config");

                        Assert.AreEqual(camera.Id, "1车液位摄像机");
                        Assert.AreEqual(camera.IsEnable, true);
                        Assert.AreEqual(camera.RunMode, RunMode.Release);
                        Assert.AreEqual(camera.IPAddress, IPAddress.Parse("192.168.1.60"));
                        Assert.AreEqual(camera.Width, 2400);
                        Assert.AreEqual(camera.Height, 600);
                        Assert.AreEqual(camera.PixelFormat, PixelFormat.Mono8);
                        Assert.AreEqual(camera.UserSet, UserSet.UserSet1);
                        Assert.AreEqual(camera.StreamChannelPacketSize, 8192);

                        Assert.AreEqual(camera.ManufacturingInformation.Manufacturer, "Hikvision");
                        Assert.AreEqual(camera.ManufacturingInformation.Model, "MV-CA060-30GM");

                        Assert.AreEqual(camera.Region.Id, "有效区域");
                        Assert.AreEqual(camera.Region.X, 0);
                        Assert.AreEqual(camera.Region.Y, 0);
                        Assert.AreEqual(camera.Region.Width, 2400);
                        Assert.AreEqual(camera.Region.Height, 600);

                        Assert.AreEqual(camera.CaptureLooper.Id, "采集循环");
                        Assert.AreEqual(camera.CaptureLooper.IsEnable, true);
                        Assert.AreEqual(camera.CaptureLooper.RunMode, RunMode.Release);
                        Assert.AreEqual(camera.CaptureLooper.Priority, ThreadPriority.Highest);
                        Assert.AreEqual(camera.CaptureLooper.Interval, 20);
                }
        }
}