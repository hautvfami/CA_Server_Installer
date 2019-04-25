using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForExam
{
    class A51
    {
        public bool[] X, Y, Z;

        public bool Maj;

        public A51()
        {
            X = new bool[] { false, true, true, false, true, true };
            Y = new bool[] { false, true, false, false, true, false, true, false };
            Z = new bool[] { true, false, true, true, false, true, true, true, false };
        }

        public bool Crypt(bool input)
        {
            calMaj();
            if (X[1] == Maj) rollX();
            if (Y[3] == Maj) rollY();
            if (Z[3] == Maj) rollZ();
            return input ^ (X[5] ^ Y[7] ^ Z[8]);
        }

        public void rollX() {
            bool temp = X[2] ^ X[4] ^ X[5];
            for (int i = 5; i > 0; i--)
            {
                X[i] = X[i - 1];
            }
            X[0] = temp;
        }
        public void rollY() {
            bool temp = Y[6] ^ Y[7];
            for (int i = 7; i > 0; i--)
            {
                Y[i] = Y[i - 1];
            }
            Y[0] = temp;
        }
        public void rollZ() {
            bool temp = Z[2] ^ Z[7] ^ Z[8];
            for (int i = 8; i > 0; i--)
            {
                Z[i] = Z[i - 1];
            }
            Z[0] = temp;
        }

        public bool calMaj()
        {
            int c = 0;
            Maj = false;
            if (X[1]) c++;
            if (Y[3]) c++;
            if (Z[3]) c++;
            if (c >= 2) Maj = true;
            return Maj;
        }
    }
}
