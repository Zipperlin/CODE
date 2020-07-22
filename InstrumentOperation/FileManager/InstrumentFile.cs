using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using FileManager;
using System.Net.Sockets;

namespace InstrumentOperation.FileManager
{
    public abstract class InstrumentFile
    {
        private string FileName;
        private string FilePath;
        private string FileSize;
        private E_FileType FileType;

        public string replacestring(string oldString, string pattern, string newString)
        {
            string sResult="";
            try
            {
                sResult = Regex.Replace(oldString, pattern, newString);
            }
            catch(Exception ex)
            {

            }
            return sResult;  
        }

        public string replacestring(string oldString, Regex regex, string newString)
        {
            string sResult = "";
            try
            {
                sResult = regex.Replace(oldString, newString);
            }
            catch (Exception ex)
            {

            }
            return sResult;
        }

        public string replacestring(string oldString, string newString)
        {
            string sResult = "";
            try
            {
                sResult = oldString.Replace(oldString, newString);
            }
            catch (Exception ex)
            {

            }
            return sResult;
        }

        public string addstring(string oldString, string newString)
        {
            oldString += newString;
            return oldString;
        }


        public InstrumentFile()
        {

        }

        public string getFileName(string filePath)
        {
            return FileName;
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public bool IsFileExisted(string FilePath)
        {
            bool bret = false;

            if (FilePath.Equals(""))
            {
                return false;
            }

            if (System.IO.File.Exists(FilePath))
            {
                bret = true;
            }
            else
            {
                //to do:打log
            }
            return bret;
        }

        /// <summary>
        /// 判断文件夹是否存在，不存在新建文件夹
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <returns></returns>
        public bool IsFolderExisted(string DirectoryPath)
        {
            bool bret = false;
            if (DirectoryPath.Equals(""))
            {
                return false;
            }
            if (System.IO.Directory.Exists(DirectoryPath))
            {
                bret = true;
            }
            else
            {
                //to do:打log
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(DirectoryPath);
                directoryInfo.Create();
            }
            return bret;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="FilePath"></param>
        public string ReadFile(string FilePath)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            StreamReader m_streamReader = new StreamReader(fs);
            //使用StreamReader类来读取文件
            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            //从数据流中读取每一行，直到文件的最后一行     
            string strLine = m_streamReader.ReadLine();
            while (strLine != null)
            {
                strLine = m_streamReader.ReadLine();
            }
            //关闭此StreamReader对象
            m_streamReader.Close();

            return strLine;
        }

        /// <summary>
        /// 读取每一行到数组
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string[] ReadFile2Array(string FilePath)
        {
            return File.ReadAllLines(FilePath);
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="strContent"></param>
        public void WriteFile(string FilePath, string strContent)
        {
            FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
            //设置当前流的位置
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            //写入内容
            m_streamWriter.Write(strContent);

            //关闭此文件
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }

        /// <summary>
        /// 将字符串数组写入文文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="strContent"></param>
        public void WriteFile(string FilePath, string[] strContent)
        {
            File.WriteAllLines(FilePath, strContent);
        }

        public XmlNode GetXMLNode(string FilePath,string NodeName)
        {
            // 1.创建一个XmlDocument类的对象
            XmlDocument doc = new XmlDocument();

            // 2.把你想要读取的xml文档加载进来
            doc.Load(FilePath);

            // 3.返回你指定的节点
            return doc.SelectSingleNode(NodeName);
       
        }

        public FileInfo CreateFile(string FilePath)
        {
            FileInfo file = new FileInfo(FilePath);
            return file;
        }

        
    }
}
