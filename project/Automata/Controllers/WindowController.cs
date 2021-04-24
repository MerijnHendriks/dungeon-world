/* WindowManager.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

using System;
using System.Collections.Generic;
using Automata.Models;

namespace Automata.Controllers
{
    public static class WindowController
    {
        private static Dictionary<int, Window> windows;
        private static Dictionary<int, View> views;

        static WindowController()
        {
            windows = new Dictionary<int, Window>();
            views = new Dictionary<int, View>();
        }

        /// <summary>
        /// Validate window id
        /// </summary>
        /// <param name="windowId">Window ID</param>
        private static void ValidateWindowId(int windowId)
        {
            if (!windows.ContainsKey(windowId))
            {
                throw new Exception($"window with id {windowId} not found");
            }
        }

        /// <summary>
        /// Validate view id
        /// </summary>
        /// <param name="viewId">View ID</param>
        private static void ValidateViewId(int viewId)
        {
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
        public static void AddWindow(int windowId, Window window)
        {
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
        public static void AddView(int viewId, View view)
        {
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
        public static Window GetWindow(int windowId)
        {
            ValidateWindowId(windowId);
            return windows[windowId];
        }

        /// <summary>
        /// Get registered view instance
        /// </summary>
        /// <param name="viewId">View ID</param>
        /// <returns>View instance</returns>
        public static View GetView(int viewId)
        {
            ValidateViewId(viewId);
            return views[viewId];
        }

        /// <summary>
        /// Switch window view to another
        /// </summary>
        /// <param name="windowId">Window ID</param>
        /// <param name="viewId">View ID</param>
        public static void SwitchView(int windowId, int viewId)
        {
            ValidateWindowId(windowId);
            ValidateViewId(viewId);

            // hide old view
            if (windows[windowId].Content != null)
            {
                HideView(windowId, viewId);
            }

            // show new view
            ShowView(windowId, viewId);
        }

        /// <summary>
        /// Show the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void ShowWindow(int windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnShow();
            windows[windowId].Show();
        }

        /// <summary>
        /// Show the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void ShowView(int windowId, int viewId)
        {
            ValidateWindowId(windowId);

            windows[windowId].Content = views[viewId];
            View view = (View)windows[windowId].Content;
            view.OnShow();
        }

        /// <summary>
        /// Hide the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void HideWindow(int windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnHide();
            windows[windowId].Hide();
        }

        /// <summary>
        /// Hide the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void HideView(int windowId, int viewId)
        {
            ValidateWindowId(windowId);
            View view = (View)windows[windowId].Content;

            if (view == null)
            {
                // no view assigned
                return;
            }

            view.OnHide();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="windowId">Window ID</param>
        public static void CloseWindow(int windowId)
        {
            ValidateWindowId(windowId);
            windows[windowId].OnClose();
            windows[windowId].Close();
        }
    }
}
