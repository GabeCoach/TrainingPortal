﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading.Tasks;

namespace MGCTrainingPortalAPI.Logger
{
    public class Logger
    {
        public async void LogData(string sDataToLog)
        {
            try
            {
                StreamWriter oWrite = new StreamWriter(Constants.Constants.productionLoggerFileLocation, true);
                await oWrite.WriteLineAsync("DATETIME: " + DateTime.Now.ToString() + "; " + sDataToLog);
                oWrite.Close();
            }
            catch (Exception ex)
            {
                StreamWriter oWrite = new StreamWriter(Constants.Constants.productionLoggerFileLocation, true);
                await oWrite.WriteLineAsync("DATETIME: " + DateTime.Now.ToString() + "; LOGGING EXCEPTION: " + ex.Message + "; LOGGING INNER EXCEPTION: " + ex.InnerException);
                oWrite.Close();
            }
        }
    }
}