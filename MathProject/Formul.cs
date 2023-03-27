

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace MathProject
{
    public enum Priority_Enum
    {
        High,Medium,Low
    }
   public class Formul
    { 
        static Random random = new Random();


        public static List<Formul>? ALL_FORMULS;
        public string Name { get; private set; }
        public string Definition { get; private set; }

        public Priority_Enum Priority { get; set; }

        #region ToCreate
        public string[] ConfusingAnswers { get; set; }
        #endregion


        public static void update_formuls()
        {
            ALL_FORMULS = INIT.UPLOAD_FORMULS();
        }

        public static Formul[] generate_arr(int capacity) {
            #region first_setup
            if (ALL_FORMULS == null) ALL_FORMULS = INIT.UPLOAD_FORMULS();
            #endregion
            Formul[] arrFormuls = new Formul[capacity];
            int[] arrIndexes = new int[capacity];
            int index = 0;
            while(index != capacity)
            {
                int possibleindex = random.Next(0, ALL_FORMULS.Count);
                bool taken = true;
                for(int i = 0;i < index; i++)
                {
                    if (arrIndexes[i] == possibleindex) {
                        taken = false;break;     
                    }
                }
                if (taken) {
                    arrIndexes[index] = possibleindex;
                    arrFormuls[index] = ALL_FORMULS[possibleindex]; index++; }
            }

            return arrFormuls;
        }
        public Formul(string name, string definition,string[] confusingAnswers,Priority_Enum priority)
        {
            Name = name;
            Definition = definition;
            ConfusingAnswers= confusingAnswers;
            Priority = priority;
        }

    }
}
