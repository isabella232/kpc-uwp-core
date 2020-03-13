/**
 * WindowManager.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;


namespace KanoComputing.Display {

    public class WindowManager : IWindowManager {

        /// <summary>Gets the screen resolution in effective pixels (raw pixel 
        /// resolution with scaling applied).</summary>
        /// <returns>Windows.Foundation.Size with width and height</returns>
        public virtual Size GetEffectiveScreenSize() {
            DisplayInformation display = DisplayInformation.GetForCurrentView();

            // Get the screen resolution (APIs available from 14393 onward).
            Size resolution = new Size(
                display.ScreenWidthInRawPixels,
                display.ScreenHeightInRawPixels);

            // Get the resolution scaling factor.
            double scale = display.ResolutionScale == ResolutionScale.Invalid ?
                1 : display.RawPixelsPerViewPixel;

            // Calculate the screen size in effective pixels. 
            return new Size(resolution.Width / scale, resolution.Height / scale);
        }

        /// <summary>Sets the window to be maximised and take up the entire screen
        /// while the taskbar remains visible. This is not fullscreen.</summary>
        /// <remarks>Calling this function only works for the next launch of the
        /// app.</remarks>
        public void MaximiseWindow() {
            Size windowSize = this.GetEffectiveScreenSize();
            this.SetWindowSize(windowSize);
        }

        /// <summary>Sets the preffered application window size.</summary>
        /// <param name="size">Windows.Foundation.Size with width and height</param>
        /// <remarks>Calling this function only works for the next launch of the 
        /// app.</remarks>
        public virtual void SetWindowSize(Size size) {
            ApplicationView.PreferredLaunchViewSize = size;
            ApplicationView.PreferredLaunchWindowingMode =
                ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
    }
}
