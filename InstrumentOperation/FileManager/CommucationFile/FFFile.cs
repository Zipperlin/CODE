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

        public bool FFGenerateFuncCode(S_FunctionFileProperties fileProperties, S_FuncItemInfo info)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if (m_file.IsFileExisted(fileProperties.UserAppPath))
            {
                string[] content = m_file.ReadFile2Array(fileProperties.UserAppPath);
                ReplaceFuncInfo(E_FuncFileType.e_USERAPP, content, info, fileProperties);
            }
            return false;
        }

        public bool FFGenerateDDCode(S_DDFileProperties fileProperties)
        {
            m_file = filefactory.createFile(E_FileType.e_FF_File);
            if (m_file.IsFileExisted(fileProperties.FFSeriesDDlPath))
            {
                string[] content = m_file.ReadFile2Array(fileProperties.FFSeriesDDlPath);
                ReplaceDDInfo(E_DDFileType.e_FFSeriesDll, content, fileProperties);
            }

            if (m_file.IsFileExisted(fileProperties.FFSeriesPath))
            {
                string[] content = m_file.ReadFile2Array(fileProperties.FFSeriesPath);
                ReplaceDDInfo(E_DDFileType.e_FFSeries, content, fileProperties);
            }

            if (m_file.IsFileExisted(fileProperties.FFSeriesTBDllPath))
            {
                string[] content = m_file.ReadFile2Array(fileProperties.FFSeriesTBDllPath);
                ReplaceDDInfo(E_DDFileType.e_FFSeriesTBDll, content, fileProperties);
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
                else if (content[i].Contains("aucDevice_ID[32]"))
                {
                    content[i] = m_file.replacestring(content[i], "\"[^\"]*\"", "\""+info.DevID+ "\"");
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

        private void ReplaceFuncInfo(E_FuncFileType type, string[] content, S_FuncItemInfo info, S_FunctionFileProperties fileProperties)
        {
            switch (type)
            {
                case E_FuncFileType.e_USERAPP:
                    for (int i = 0; i < content.Length; i++)
                    {
                        if (0 == fileProperties.AINum && content[i].Equals("#include \"fbaiext.h\""))
                        {
                            content[i] = m_file.addstring("//",content[i]);
                        }
                        if (0 == fileProperties.AONum && content[i].Equals("#include \"fbaoext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.DINum && content[i].Equals("#include \"fbdiext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.DONum && content[i].Equals("#include \"fbdoext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.RANum && content[i].Equals("#include \"fbraext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.PIDNum && content[i].Equals("#include \"fbpidext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.SCNum && content[i].Equals("#include \"fbscext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                        if (0 == fileProperties.BGNum && content[i].Equals("#include \"fbbgext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }

                        if (0 == fileProperties.ISNum && content[i].Equals("#include \"fbisext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }

                        if (0 == fileProperties.LLNum && content[i].Equals("#include \"fbllagext.h\""))
                        {
                            content[i] = m_file.addstring("//", content[i]);
                        }
                    }
                        
                    break;
                default:
                    break;
            }

            m_file.WriteFile(fileProperties.UserAppPath, content);
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


        private void ReplaceDDInfo(E_DDFileType type, string[] content,S_DDFileProperties fileProperties)
        {
            switch (type)
            {
                case E_DDFileType.e_FFSeriesDll:
                   
                    break;
                case E_DDFileType.e_FFSeries:
                    for (int i = 0; i < content.Length; i++)
                    {
                        content[i]=ReplaceFFSeriesh(content[i],fileProperties);
                    }
                    m_file.WriteFile(fileProperties.FFSeriesPath, content);
                    break;
                case E_DDFileType.e_FFSeriesTBDll:
                    for (int i = 0; i < content.Length; i++)
                    {
                        content[i] = ReplaceFFSeriesXTBddl(content[i], fileProperties);
                    }
                    m_file.WriteFile(fileProperties.FFSeriesTBDllPath, content);
                    break;
                default:
                    break;
            }    
        }

        private string ReplaceFFSeriesh(string content, S_DDFileProperties fileProperties)
        {
            if (content.Contains("#define _IMPORT_AI_BLOCK") && fileProperties.FunctionFileProperties.AINum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_AO_BLOCK") && fileProperties.FunctionFileProperties.AONum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_DI_BLOCK") && fileProperties.FunctionFileProperties.DINum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_DO_BLOCK") && fileProperties.FunctionFileProperties.DONum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_PID_BLOCK") && fileProperties.FunctionFileProperties.PIDNum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_BG_BLOCK") && fileProperties.FunctionFileProperties.BGNum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_RA_BLOCK") && fileProperties.FunctionFileProperties.RANum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }

            if (content.Contains("#define _IMPORT_SIGNAL_CHARACTERIZER_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_INTEGRATOR_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_INPUT_SELECTOR_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_ARITHMETIC_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_LEAD_LAG_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_SETPOINT_RAMP_GENERATOR_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_DEADTIME_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define _IMPORT_TIMER_BLOCK"))
            {
                return content;
            }

            if (content.Contains("#define MANUFACTURER_ID_VALUE"))
            {
                content = m_file.replacestring(content, @"0x0017C9", fileProperties.ManufactureInfo.ManufactureID);
                return content;
            }

            if (content.Contains("#define MANUFACTURER_ID_LABEL"))
            {
                content = m_file.replacestring(content, "\"[^\"]*\"", "\"" + fileProperties.ManufactureInfo.ManufactureName) + "\"";
                return content;
            }

            if (content.Contains("#define DEVICE_TYPE_VALUE"))
            {
                content = m_file.replacestring(content, @"0x0001", fileProperties.ManufactureInfo.DevType);
                return content;
            }

            if (content.Contains("#define DEVICE_TYPE_LABEL"))
            {
                content = m_file.replacestring(content, "\"[^\"]*\"", "\"" + fileProperties.ManufactureInfo.DevName) + "\"";
                return content;
            }

            if (content.Contains("#define DEVICE_REVISION_VALUEL"))
            {
                content = m_file.replacestring(content, @"1", fileProperties.ManufactureInfo.DevID);
                return content;
            }

            if (content.Contains("#define DD_REVISION_VALUE"))
            {
                //content = m_file.replacestring(content, @"1", fileProperties.ManufactureInfo.DevID);
                return content;
            }

            if (content.Contains("|en|MASS_FLOW"))
            {
                //content = m_file.replacestring(content, @"0x01", fileProperties.TransferFilePath.);
                return content;
            }

            return content;
        }

        private string ReplaceFFSeriesXTBddl(string content, S_DDFileProperties fileProperties)
        {

            if (content.Contains("#define _IMPORT_PID_BLOCK") && fileProperties.FunctionFileProperties.PIDNum < 1)
            {
                content = m_file.replacestring(content, @"0", "1");
                return content;
            }
            return content;
        }


    }
}
