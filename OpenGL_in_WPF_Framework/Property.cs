﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameFormatReader.Common;

namespace CollisionEditor
{
    public class Property : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged overhead

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Bitfield 1

        #region CameraID

        private int m_camID;

        /// <summary>
        /// Camera ID. Purpose unknown.
        /// </summary>
        public int CameraID
        {
            get { return m_camID; }
            set
            {
                if (value != m_camID)
                {
                    m_camID = value;

                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region ExitIndex

        private int m_exitID;

        /// <summary>
        /// The index of an SCLS entry to use to exit the map. If the index is 63/0x3F, no exit is triggered.
        /// </summary>
        public int ExitIndex
        {
            get { return m_exitID; }
            set 
            {
                if (value != m_exitID)
                {
                    m_exitID = value;

                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region SoundID

        private int m_soundID;

        /// <summary>
        /// The sound that plays when an actor walks across the face.
        /// </summary>
        public int SoundID
        {
            get { return m_soundID; }
            set 
            { 
                if (value != m_soundID) 
                { 
                    m_soundID = value;

                    NotifyPropertyChanged();
                } 
            }
        }

        #endregion

        #region PolyColor

        private int m_polyColor;

        /// <summary>
        /// The index of an entry related to ENVR & Co. Colo?
        /// </summary>
        public int PolyColor
        {
            get { return m_polyColor; }
            set 
            {
                if (value != m_polyColor)
                {
                    m_polyColor = value;

                    NotifyPropertyChanged();
                }
            }
        }
        
        #endregion
        
        #endregion

        #region Bitfield 2

        #region Attribute Code

        private int m_attribCode;

        public int AttributeCode
        {
            get { return m_attribCode; }
            set 
            {
                if (value != m_attribCode)
                {
                    m_attribCode = value;

                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Ground Code

        private int m_groundCode;

        public int GroundCode
        {
            get { return m_groundCode; }
            set 
            { 
                if (value != m_groundCode)
                {
                    m_groundCode = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #region Link Number

        private int m_linkNo;

        public int LinkNumber
        {
            get { return m_linkNo; }
            set 
            { 
                if (value != m_linkNo)
                {
                    m_linkNo = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #region Special Code

        private int m_specialCode;

        public int SpecialCode
        {
            get { return m_specialCode; }
            set 
            { 
                if (value != m_specialCode)
                {
                    m_specialCode = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #region Wall Code

        private int m_wallCode;

        public int WallCode
        {
            get { return m_wallCode; }
            set 
            { 
                if (value != m_wallCode)
                {
                    m_wallCode = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #endregion

        #region Bitfield 3

        #region Camera Move BG

        private int m_camMoveBg;

        public int CamMoveBG
        {
            get { return m_camMoveBg; }
            set 
            { 
                if (value != m_camMoveBg)
                {
                    m_camMoveBg = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #region Room Camera ID

        private int m_roomCamID;

        public int RoomCamID
        {
            get { return m_roomCamID; }
            set 
            { 
                if (value != m_roomCamID)
                {
                    m_roomCamID = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #region Room Path ID

        private int m_roomPathID;

        public int RoomPathID
        {
            get { return m_roomPathID; }

            set 
            { 
                m_roomPathID = value;

                NotifyPropertyChanged();
            }
        }
        

        #endregion

        #region Room Path Point Number

        private int m_roomPathPntNo;

        public int RoomPathPointNo
        {
            get { return m_roomPathPntNo; }
            set 
            { 
                if (value != m_roomPathPntNo)
                {
                    m_roomPathPntNo = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        #endregion

        #region Camera Behavior

        private int m_cameraBehavior;

        public int CameraBehavior
        {
            get { return m_cameraBehavior; }
            set
            { 
                if (value != m_cameraBehavior)
                {
                    m_cameraBehavior = value;

                    NotifyPropertyChanged();
                }
            }
        }
        

        #endregion

        public Property()
        {

        }

        public Property(EndianBinaryReader reader)
        {
            int bitField1 = reader.ReadInt32();

            m_camID = (bitField1 & 0xFF);
            m_soundID = (bitField1 & 0x1F00) >> 0x08;
            m_exitID = (bitField1 & 0x7E000) >> 0x0D;
            m_polyColor = (bitField1 & 0x7F80000) >> 0x13;

            int bitField2 = reader.ReadInt32();

            m_linkNo = (bitField2 & 0xFF);
            m_wallCode = (bitField2 & 0xF00) >> 0x08;
            m_specialCode = (bitField2 & 0xF000) >> 0x0C;
            m_attribCode = (bitField2 & 0x1F0000) >> 0x10;
            m_groundCode = (bitField2 & 0x3E00000) >> 0x15;

            int bitField3 = reader.ReadInt32();

            m_camMoveBg = (bitField3 & 0xFF);
            m_roomCamID = (bitField3 & 0xFF00) >> 0x08;
            m_roomPathID = (bitField3 & 0xFF0000) >> 0x10;
            m_roomPathPntNo = (int)(bitField3 & 0xFF000000) >> 0x18;

            m_cameraBehavior = reader.ReadInt32();
        }
    }
}