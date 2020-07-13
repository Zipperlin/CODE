using FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstrumentOperation.FileManager.CommucationFile
{
    public class FFFile:InstrumentFile
    {
        private InstrumentFile m_file;
        private FileFactory filefactory = new FileFactory();
        public bool FFGenerateBasicCode(string filePath,S_ManufactureInfo info)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if (m_file.IsFileExisted(filePath))
            {
                string[] content = m_file.ReadFile2Array(filePath);
                ReplaceBasicInfo(content, info, filePath);


            }
            return false;
        }

        public bool FFGenerateTransferCode(S_TransferFilePath filePath,S_TransferItemInfo info)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if (m_file.IsFileExisted(filePath.XTBhPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.XTBhPath);
                ReplaceTransferInfo(E_TransferFileType.e_XTBH,content, info, filePath.XTBhPath);
            }

            if (m_file.IsFileExisted(filePath.XTBCPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.XTBCPath);
                ReplaceTransferInfo(E_TransferFileType.e_XTBC, content, info, filePath.XTBCPath);
            }

            if (m_file.IsFileExisted(filePath.XTBdPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.XTBdPath);
                ReplaceTransferInfo(E_TransferFileType.e_XTBD,content, info, filePath.XTBdPath);
            }
            return false;
        }

        public bool FFGenerateFuncCode(S_FunctionFilePath filePath, S_FuncItemInfo info)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if (m_file.IsFileExisted(filePath.UserAppPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.UserAppPath);
                ReplaceFuncInfo(E_FuncFileType.e_USERAPP, content, info, filePath.UserAppPath);
            }

            if (m_file.IsFileExisted(filePath.FFSeriesDllPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.FFSeriesDllPath);
                ReplaceFuncInfo(E_FuncFileType.e_FFSeriesDll, content, info, filePath.FFSeriesDllPath);
            }

            if (m_file.IsFileExisted(filePath.FFSeriesPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.FFSeriesPath);
                ReplaceFuncInfo(E_FuncFileType.e_FFSeries, content, info, filePath.FFSeriesPath);
            }

            if (m_file.IsFileExisted(filePath.FFSeriesTBDllPath))
            {
                string[] content = m_file.ReadFile2Array(filePath.FFSeriesTBDllPath);
                ReplaceFuncInfo(E_FuncFileType.e_FFSeriesTBDll, content, info, filePath.FFSeriesTBDllPath);
            }
            return false;
        }
        private void ReplaceBasicInfo(string[] content, S_ManufactureInfo info, string NewfilePath)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains("FB_VFD_VENDOR_NAME"))
                {
                    content[i] = m_file.replacestring(content[i], @"(?<="")(\w+?)(?="")", info.ManufactureName);
                }
                else if (content[i].Contains("ulManufacId"))
                {
                    content[i] = m_file.replacestring(content[i], @"(\w+?)(?=,)", info.ManufactureID);
                }
                else if (content[i].Contains("uDevType"))
                {
                    content[i] = m_file.replacestring(content[i], @"(\w+?)(?=,)", info.DevType);
                }
                else if (content[i].Contains("FIRMWARE_INFO gsFirmwareInfo"))
                {
                    content[i + 5] = m_file.replacestring(content[i + 5], @"(?<="")(\w+?)(?="")", info.DevID);
                }
                else if (content[i].Contains("USIGN8 SM_DEFAULT_PD_TAG[]"))
                {
                    Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);
                    content[i] = re.Replace(content[i], info.DevName);
                }
                else
                {

                }
            }

            m_file.WriteFile(NewfilePath, content);
        }

        private const string tabArray = "\t\t\t\t\t\t\t\t";

        private void ReplaceTransferInfo(E_TransferFileType type, string[] content, S_TransferItemInfo info, string NewfilePath)
        {
            switch (type)
            {
                case E_TransferFileType.e_XTBH:
                    for (int i = 0; i < content.Length; i++)
                    {
                        if (content[i].Contains("/* USER CODE BEGIN 1 */"))
                        {
                            content[i] = m_file.addstring(content[i], "\n\t" + info.paramType.ToString() + tabArray + info.paramName + ";");
                        }
                        if (content[i].Contains("X_TB"))
                        {
                            content[i] = m_file.replacestring(content[i], @"X_TB", "MTB");
                        }
                    }
                    break;
                case E_TransferFileType.e_XTBC:
                    for (int i = 0; i < content.Length; i++)
                    {
                        if (content[i].Contains("X_TB_Check_Status_Mode( X_TB * psModBlk )"))
                        {
                            content[i] = m_file.replacestring(content[i], @"X_TB", "MTB");
                        }
                        else if(content[i].Contains("psModBlk->sMassFlow.ucStatus = SUB_DEVICE_FAILURE | (psModBlk->sMassFlow.ucStatus & 0x03);")
                            ||content[i].Contains("psModBlk->sMassFlow.ucStatus = GOOD_C;")
                            || content[i].Contains("psModBlk->sMassFlow.ucStatus = BAD+SUB_OS;"))
                        {
                            string stemp = content[i];                          
                            content[i] = m_file.replacestring(content[i], @"sMassFlow", info.paramName);
                            content[i] = m_file.addstring(content[i], "\n\t" + stemp);
                        }
                        else if(content[i].Contains("psModBlk->sMassFlow.fValue = gsWalsnData.fMassFlow;")
                            || content[i].Contains("psModBlk->sCheckState.ucValue = gsWalsnData.ucCmFeatureKey;")
                            || content[i].Contains("gsWalsnData.fBSetp  = psModBlk->sBSetp.fValue;")
                            || content[i].Contains("gsWalsnData.uResetTOT               = psModBlk->sResetTOT.ucValue;"))
                        {
                            if (info.itemType.Equals("AI"))
                            {
                                string stemp = content[i];
                                content[i] = m_file.replacestring(content[i], @"sMassFlow", info.paramName);
                                content[i] = m_file.addstring(content[i], "\n\t" + stemp);
                            }
                            else if(info.itemType.Equals("DI"))
                            {
                                string stemp = content[i];
                                content[i] = m_file.replacestring(content[i], @"sCheckState", info.paramName);
                                content[i] = m_file.addstring(content[i], "\n\t" + stemp);
                            }
                            else if (info.itemType.Equals("AO"))
                            {
                                string stemp = content[i];
                                content[i] = m_file.replacestring(content[i], @"fBSetp", info.paramName);
                                content[i] = m_file.addstring(content[i], "\n\t" + stemp);
                            }
                            else if (info.itemType.Equals("DO"))
                            {
                                string stemp = content[i];
                                content[i] = m_file.replacestring(content[i], @"uResetTOT", info.paramName);
                                content[i] = m_file.addstring(content[i], "\n\t" + stemp);
                            }
                            else
                            {

                            }
                        }
                        else
                        {

                        }
                    }

                    //for (int i = 0; i < content.Length; i++)
                    //{
                    //    if (content[i].Contains("psModBlk->sMassFlow"))
                    //    {
                    //        content[i] = m_file.replacestring(content[i], @"psModBlk->sMassFlow", "//psModBlk->sMassFlow");
                    //    }
                    //}

                    break;
                case E_TransferFileType.e_XTBD:
                    break;
            }
            m_file.WriteFile(NewfilePath, content);
        }

        private void ReplaceFuncInfo(E_FuncFileType type, string[] content, S_FuncItemInfo info, string NewfilePath)
        {
            switch (type)
            {
                case E_FuncFileType.e_USERAPP:
                   
                    break;
                case E_FuncFileType.e_FFSeriesDll:
                    break;
                case E_FuncFileType.e_FFSeries:
                    break;
                case E_FuncFileType.e_FFSeriesTBDll:
                    break;
                default:
                    break;
            }
        }

        private void ReplaceFuncUserApp(string[] content, string NewfilePath)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains("fbaiext.h"))
                {
                    content[i] = m_file.replacestring(content[i], @"#", "//#");
                }
            }
          
        }

    }
}
