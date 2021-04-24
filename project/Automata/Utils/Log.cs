﻿/* Log.cs
 * Authors: 
 * - Merijn Hendriks
 * - Shaquille Louisa
 * License: NCSA
 */

using System;
using System.Diagnostics;

namespace Automata.Utils
{
    public enum ELogLevel
    {
        Debug = 0,
        Info,
        Warning,
        Error,
        None
    }

    public static class Log
    {
        private static string filepath = "./debug.log";
        private static ELogLevel mode;
        private static TraceListener listener;

        static Log()
        {
            mode = ELogLevel.Debug;
            listener = new DelimitedListTraceListener(filepath);   
            Trace.Listeners.Add(listener);  
        }

        /// <summary>
        /// Write text to console
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="level">Level</param>
        private static void Write(string text, ELogLevel level = ELogLevel.Debug)
        {
            if ((int)level >= (int)mode)
            {
                Trace.WriteLine(text);
                Trace.Flush();
            }
        }

        /// <summary>
        /// Write debug message to console
        /// </summary>
        /// <param name="text">Text</param>
        public static void Debug(string text)
        {
            Write($"[DEBUG] {text}");
        }

        /// <summary>
        /// Write info message to console
        /// </summary>
        /// <param name="text">Text</param>
        public static void Info(string text)
        {
            Write($"[INFO] {text}", ELogLevel.Info);
        }

        /// <summary>
        /// Write warning message to console
        /// </summary>
        /// <param name="text">Text</param>
        public static void Warning(string text)
        {
            Write($"[WARNING] {text}", ELogLevel.Warning);
        }

        /// <summary>
        /// Write error message to console
        /// </summary>
        /// <param name="text">Text</param>
        public static void Error(string text)
        {
            Write($"[ERROR] {text}", ELogLevel.Error);
        }
    }
}
