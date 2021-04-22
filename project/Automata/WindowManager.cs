/* WindowManager.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

using System;
using System.Collections.Generic;

namespace Automata
{
    public static class WindowManager
    {
        private static Dictionary<string, Window> windows;
        private static Dictionary<string, View> views;

        static WindowManager()
        {
            windows = new Dictionary<string, Window>();
            views = new Dictionary<string, View>();
        }

        /// <summary>
        /// Validate window id
        /// </summary>
        /// <param name="windowId">Window ID</param>
        private static void ValidateWindowId(string windowId)
        {
            if (string.IsNullOrWhiteSpace(windowId))
            {
                throw new Exception("id is null");
            }

            if (!windows.ContainsKey(windowId))
            {
                throw new Exception($"window with id {windowId} not found");
            }
        }

        /// <summary>
        /// Validate view id
        /// </summary>
        /// <param name="viewId">View ID</param>
        private static void ValidateViewId(string viewId)
        {
            if (string.IsNullOrWhiteSpace(viewId))
            {
                throw new Exception("id is null");
            }

            if (!views.ContainsKey(viewId))
            {
                throw new Exception($"view with id {viewId} not found");
            }
        }

        /// <summary>
        /// Register the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        /// <param name="window">Window instance</param>
        public static void AddWindow(string windowId, Window window)
        {
            if (string.IsNullOrWhiteSpace(windowId))
            {
                throw new Exception("id is null");
            }

            if (windows.ContainsKey(windowId))
            {
                throw new Exception($"id {windowId} is already registered");
            }

            if (window == null)
            {
                throw new Exception("window is null");
            }

            windows[windowId] = window;
        }

        /// <summary>
        /// Register the view
        /// </summary>
        /// <param name="viewId">View ID</param>
        /// <param name="window">View instance</param>
        public static void AddView(string viewId, View view)
        {
            if (string.IsNullOrWhiteSpace(viewId))
            {
                throw new Exception("id is null");
            }

            if (windows.ContainsKey(viewId))
            {
                throw new Exception($"id {viewId} is already registered");
            }

            if (view == null)
            {
                throw new Exception("view is null");
            }

            views[viewId] = view;
        }

        /// <summary>
        /// Get registered window instance
        /// </summary>
        /// <param name="windowId">Window ID</param>
        /// <returns>Window instance</returns>
        public static Window GetWindow(string windowId)
        {
            ValidateWindowId(windowId);
            return windows[windowId];
        }

        /// <summary>
        /// Get registered view instance
        /// </summary>
        /// <param name="viewId">View ID</param>
        /// <returns>View instance</returns>
        public static View GetView(string viewId)
        {
            ValidateViewId(viewId);
            return views[viewId];
        }

        /// <summary>
        /// Switch window view to another
        /// </summary>
        /// <param name="windowId">Window ID</param>
        /// <param name="viewId">View ID</param>
        public static void SwitchView(string windowId, string viewId)
        {
            View view;

            ValidateWindowId(windowId);
            ValidateViewId(viewId);

            // hide old view
            if (windows[windowId].Content != null)
            {
                view = (View)windows[windowId].Content;
                view.OnHide();
            }

            // show new view
            windows[windowId].Content = views[viewId];
            view = (View)windows[windowId].Content;
            view.OnShow();
        }

        /// <summary>
        /// Show the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void ShowWindow(string windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnShow();
            windows[windowId].Show();
        }

        /// <summary>
        /// Hide the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void HideWindow(string windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnHide();
            windows[windowId].Hide();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void CloseWindow(string windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnClose();
            windows[windowId].Close();
        }
    }
}
