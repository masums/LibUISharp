﻿using LibUISharp.Native.Libraries;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native.SafeHandles
{
    /// <summary>
    /// Represents a wrapper class for a control handle.
    /// </summary>
    public sealed class SafeControlHandle : LibuiSafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeControlHandle"/> class.
        /// </summary>
        /// <param name="existingHandle">An <see cref="IntPtr"/> object that represents a pre-existing handle to use.</param>
        /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization
        /// phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
        public SafeControlHandle(IntPtr existingHandle, bool ownsHandle = true) : base(existingHandle, ownsHandle) { }

        /// <summary>
        /// Returns the native control handle for this control.
        /// </summary>
        /// <returns>An <see cref="UIntPtr"/> representing the controls handle.</returns>
        public UIntPtr DangerousGetControlHandle() => LibuiLibrary.uiControlHandle(handle);

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            LibuiLibrary.uiControlDestroy(handle);
            handle = IntPtr.Zero;

            if (PlatformHelper.IsWinNT)
                return Marshal.GetLastWin32Error() == 0;
            return true;
        }
    }
}