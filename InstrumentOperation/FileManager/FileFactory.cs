using FileManager;
using InstrumentOperation.FileManager.CommucationFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentOperation.FileManager
{
    public class FileFactory
    {
        private InstrumentFile m_file;
        public InstrumentFile createFile(E_FileType type)
        {
            switch(type)
            {
                case E_FileType.e_FF_File:
                    m_file= new FFFile();
                    break;
                case E_FileType.e_HART_File:
                    m_file= new HartFile();
                    break;
                case E_FileType.e_PA_File:
                    m_file= new PAFile();
                    break;
                default:
                    break;
            }
            return m_file;
        }

    }
}
