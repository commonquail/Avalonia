﻿// -----------------------------------------------------------------------
// <copyright file="MouseDevice.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Win32.Input
{
    using System;
    using Perspex.Input;
    using Perspex.Win32.Interop;

    public class WindowsMouseDevice : MouseDevice
    {
        private static WindowsMouseDevice instance = new WindowsMouseDevice();

        public static WindowsMouseDevice Instance
        {
            get { return instance; }
        }

        public WindowImpl CurrentWindow
        {
            get;
            set;
        }

        public new Point Position
        {
            get { return base.Position; }
            internal set { base.Position = value; }
        }

        protected override Point GetClientPosition()
        {
            UnmanagedMethods.POINT p;
            UnmanagedMethods.GetCursorPos(out p);
            UnmanagedMethods.ScreenToClient(this.CurrentWindow.Handle.Handle, ref p);
            return new Point(p.X, p.Y);
        }
    }
}

