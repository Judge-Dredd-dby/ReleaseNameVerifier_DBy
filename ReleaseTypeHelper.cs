﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNameVerifier
{
    public static class ReleaseTypeHelper
    {
        public static List<string> GetReleaseTypes()
        {
            return new List<string>
        {
            "BluRay",
            "WEB-DL",
            "WEBRip",
            "DVDR",
            "CAM",
            "TS",
            "HDRip",
            "HDTV",
            "BDRip",
            "DVDScr",
            "VHSRip",
            "DVDRip",
            "DVD",
            "VODRip",
            "PDTV",
            "DTHRip",
            "HDCAM",
            "HDDVD",
            "TVRip",
            "Telesync",
            "Workprint",
            "BRRip",
            "R5",
            "Telecine",
            "Screener",
            "AMZN.WEB-DL",
            "NF.WEB-DL",
            "HULU.WEB-DL",
            "iTunes.WEB-DL",
            "AMZN.WEBRip",
            "NF.WEBRip",
            "HULU.WEBRip",
            "iTunes.WEBRip"
            // Add more release types as needed
        };
        }
    }

}
