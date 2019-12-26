using System;
using System.Collections.Generic;
using System.Text;

namespace MangaEye
{
    public sealed class MdCore
    {
        public static readonly string PROGRAM_NAME = "MangaEye";
        public static readonly string PROGRAM_VERSION = "0000";
        public string CurrentFolderPath { get; set; }

        private static readonly MdCore instance = new MdCore();
        static MdCore()
        {

        }

        private MdCore()
        {

        }

        public static MdCore Instance => instance;

    }
}
