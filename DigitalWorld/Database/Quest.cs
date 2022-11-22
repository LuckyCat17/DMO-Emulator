using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yggdrasil.Helpers;
using System.IO;
using Digital_World;

namespace Yggdrasil.Database
{
    public class Quest1
    {

    }

    public class Enumerations
    {
        // ========== type
        public enum eQUEST_TYPE
        {
            QT_SUB = 0, QT_MAIN, QT_DAILY, QT_REPEAT, QT_EVENTREPEAT, QT_ACHIEVE,
            QT_JOINTPROGRESS,
            QT_TUTORIAL,
            QT_XANTI_JOINTPROGRESS,
            //QT_TIME,
        };
        public eQUEST_TYPE m_eQuestType;
        public eQUEST_TYPE GetQuestType()
        {
            return m_eQuestType;
        }
        public void SetQuestType(eQUEST_TYPE type)
        {
            m_eQuestType = type;
        }
        //public const bool IsQuestType(eQUEST_TYPE type);



        // ========== Comp Target
        public enum eQUEST_TARGET
        {
            QTG_SELF = 0,
            QTG_NPC,
            QTG_COMPLETE
        };
        public eQUEST_TARGET m_eQuestTargetType;
        public int m_nQuestTargetValue1;
        public eQUEST_TARGET GetQuestTarget() { return m_eQuestTargetType; }
        public void SetQuestTarget(eQUEST_TARGET target) { m_eQuestTargetType = target; }
        public int GetQuestTargetValue1() { return m_nQuestTargetValue1; }
        public void SetQuestTargetValue1(int nValue) { m_nQuestTargetValue1 = nValue; }



        // ========== StartTarget
        public enum eST_TYPE
        {
            ST_NPC,
            ST_DIGIVICE,
        };

        public eST_TYPE m_eStartTarget_Type;
        //DWORD m_dwStartTarget_ID;
        public uint m_dwStartTarget_ID;
        public void SetStartTarget_Type(eST_TYPE type) { m_eStartTarget_Type = type; }
        public void SetStartTarget_ID(uint dwID) { m_dwStartTarget_ID = dwID; }
        public eST_TYPE GetStartTarget_Type() { return m_eStartTarget_Type; }
        public uint GetStartTarget_ID() { return m_dwStartTarget_ID; }


        // ========== eEVENT
        public enum eEVENT
        {
            EVENT_QUEST_START,
            EVENT_QUEST_PROC,
            EVENT_QUEST_COMPLEAT,
            EVENT_QUEST_REQUITE,
            EVENT_MAX_COUNT,
        };

        public int m_nEvent = Convert.ToInt32(eEVENT.EVENT_MAX_COUNT);

        // ==== Uniq ID       
        protected uint m_dwUniqID;
        public uint GetUniqID() { return m_dwUniqID; }
        public void SetUniqID(uint dwUniqID) { m_dwUniqID = dwUniqID; }

        // ==== Model ID
        public uint m_dwModelID_Recv;
        public uint m_dwModelID_Comp;
        public uint GetModelID_Recv() { return m_dwModelID_Recv; }
        void SetModelID_Recv(uint dwID) { m_dwModelID_Recv = dwID; }
        uint GetModelID_Comp() { return m_dwModelID_Comp; }
        void SetModelID_Comp(uint dwID) { m_dwModelID_Comp = dwID; }


        // ==== Level       
        public ushort m_nLevel;
        public ushort GetLevel() { return m_nLevel; }
        void SetLevel(ushort nLevel) { m_nLevel = nLevel; }

        // ==== ToolPos 
        //public CsPoint m_ptToolPos;
        
	    //public CsPoint GetToolPos() { return m_ptToolPos; }
        //public void SetToolPos(CsPoint pos) { m_ptToolPos = pos; }

        // ==== ManageID        
        public uint m_dwManageID;
        public uint GetManageID() { return m_dwManageID; }
        void SetManageID(uint dwMngID) { m_dwManageID = dwMngID; }

        // ==== Enable        
        public bool m_bActiveQuest;
        public bool IsActive() { return m_bActiveQuest; }
        void SetActive(bool bActive) { m_bActiveQuest = bActive; }

        
        public bool m_bImmediate;
        public bool IsImmediate() { return m_bImmediate; }
        void SetImmeiate(bool bImmediate) { m_bImmediate = bImmediate; }

    }
}
