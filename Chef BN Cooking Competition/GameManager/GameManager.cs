using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class GameManager
    {
        public GameManager()
        {
            Thread mainThread = new Thread(StartGame);
            mainThread.Start();
        }

        private void StartGame()
        {
            while (true)
            { 
            
            }
        }
    }

}
