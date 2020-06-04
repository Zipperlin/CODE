﻿using InstrumentOperation.Common;
using InstrumentOperation.FileManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InstrumentOperation.Config
{
    public class ConfigUIFile : InstrumentFile
    {
        private S_ConfigUIInfo m_configUIInfo;
        private ObservableCollection<ItemTreeData> m_configData;
        private ObservableCollection<ItemTreeData> ZeroStepList;
        private ObservableCollection<ItemTreeData> FirstStepList;
        private ObservableCollection<ItemTreeData> SecondStepList;

        
        public override string replacestring()
        {
            return "";
        }

        public S_ConfigUIInfo GetConfigUIInfo()
        {
            m_configUIInfo = new S_ConfigUIInfo();
            m_configUIInfo.treeData = GetConfigTreeData("../../../settingconfig.xml");
            return m_configUIInfo;
        }

        private ObservableCollection<ItemTreeData> GetConfigTreeData(string FilePath)
        {
            m_configData = new ObservableCollection<ItemTreeData>();
            ZeroStepList = new ObservableCollection<ItemTreeData>();
            FirstStepList= new ObservableCollection<ItemTreeData>();
            SecondStepList = new ObservableCollection<ItemTreeData>();

            XmlNode xmlnode=GetXMLNode(FilePath, "rootItem");
            XmlElement xeroot = (XmlElement)xmlnode;
            string rootname = xeroot.GetAttribute("name").ToString();

            int zeroIndex = 0;
            int firstIndex = 0;
            int secondIndex = 0;

            foreach (XmlNode zeroNode in xmlnode.ChildNodes)
            {       
                string dsf = zeroNode.InnerText;
                string sdf = zeroNode.Name;

                XmlElement xe = (XmlElement)zeroNode;
                string zeroname = xe.GetAttribute("name").ToString();
                ItemTreeData item = new ItemTreeData();
                item.itemName = zeroname;
                item.itemId = zeroIndex;
                item.IsExpanded = false;
                ZeroStepList.Add(item);
                
                if (zeroNode.HasChildNodes)
                {
                    foreach (XmlNode firstNode in zeroNode.ChildNodes)
                    {
                        string firstinnerText = firstNode.InnerText;
                        string firstName = firstNode.Name;

                        XmlElement firstele = (XmlElement)firstNode;
                        string firstname = firstele.GetAttribute("name").ToString();
                        ItemTreeData itemFirst = new ItemTreeData();
                        itemFirst.itemName = firstname;
                        itemFirst.itemParent = zeroIndex;
                        itemFirst.itemId = firstIndex;
                        itemFirst.IsExpanded = false;
                        FirstStepList.Add(itemFirst);
                        if (firstNode.HasChildNodes)
                        {
                            foreach (XmlNode secondNode in firstNode.ChildNodes)
                            {
                                string secondinnerText = secondNode.InnerText;
                                string secondName = secondNode.Name;

                                XmlElement secondele = (XmlElement)secondNode;
                                string secondname = secondele.GetAttribute("name").ToString();
                                ItemTreeData itemSecond = new ItemTreeData();
                                itemSecond.itemName = secondname;
                                itemSecond.itemParent = firstIndex;
                                itemSecond.itemId = secondIndex;
                                itemSecond.IsExpanded = false;
                                SecondStepList.Add(itemSecond);
                                secondIndex++;
                            }
                        }
                        firstIndex++;
                    }
                }
                zeroIndex++;
            }
            m_configData.Add(GetTreeData(rootname));
            return m_configData;
         }

        private ItemTreeData GetTreeData(string rootName)
        {
            /*
             *  rootItem
             *      |----zeroTreeItem
             *                 |----firstTreeItem
             *                            |----secondTreeItem
             */

            // 根节点
            ItemTreeData rootItem = new ItemTreeData();
            rootItem.itemId = -1;
            rootItem.itemName = rootName;
            rootItem.itemStep = -1;
            rootItem.itemParent = -1;
            rootItem.IsExpanded = true; // 根节点默认展开
            rootItem.IsSelected = false;

            for (int i = 0; i < this.ZeroStepList.Count; i++) // 零级分类
            {
                ItemTreeData zeroStepItem = this.ZeroStepList[i];
                ItemTreeData zeroTreeItem = new ItemTreeData();
                zeroTreeItem.itemId = zeroStepItem.itemId;
                zeroTreeItem.itemName = zeroStepItem.itemName;
                zeroTreeItem.itemStep = zeroStepItem.itemStep;
                zeroTreeItem.itemParent = zeroStepItem.itemParent;
                if (i == 0)
                {
                    zeroTreeItem.IsExpanded = false; // 只有需要默认选中的第一个零级分类是展开的
                }
                zeroTreeItem.IsSelected = false;
                rootItem.Children.Add(zeroTreeItem); // 零级节点无条件加入根节点

                for (int j = 0; j < this.FirstStepList.Count; j++) // 一级分类
                {
                    ItemTreeData firstStepItem = this.FirstStepList[j];
                    if (firstStepItem.itemParent == zeroStepItem.itemId) //零级节点添加一级节点
                    {
                        ItemTreeData firstTreeItem = new ItemTreeData();
                        firstTreeItem.itemId = firstStepItem.itemId;
                        firstTreeItem.itemName = firstStepItem.itemName;
                        firstTreeItem.itemStep = firstStepItem.itemStep;
                        firstTreeItem.itemParent = firstStepItem.itemParent;
                        if (j == 0)
                        {
                            firstTreeItem.IsExpanded = false; // 只有需要默认选中的第一个一级分类是展开的
                        }
                        firstTreeItem.IsSelected = false;
                        zeroTreeItem.Children.Add(firstTreeItem);

                        for (int k = 0; k < this.SecondStepList.Count; k++) // 二级分类
                        {
                            ItemTreeData secondStepItem = this.SecondStepList[k];
                            if (secondStepItem.itemParent == firstStepItem.itemId) // 一级节点添加二级节点
                            {
                                ItemTreeData secondTreeItem = new ItemTreeData();
                                secondTreeItem.itemId = secondStepItem.itemId;
                                secondTreeItem.itemName = secondStepItem.itemName;
                                secondTreeItem.itemStep = secondStepItem.itemStep;
                                secondTreeItem.itemParent = secondStepItem.itemParent;
                                if (k == 0)
                                {
                                    // 默认选中第一个二级分类
                                    secondTreeItem.IsExpanded = false; // 已经没有下一级了，这个属性无所谓
                                    secondTreeItem.IsSelected = true;
                                }
                                firstTreeItem.Children.Add(secondTreeItem);
                            }
                        }
                    }
                }
            }

            return rootItem;
        }
    }
}