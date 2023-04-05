using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Class
{
    
    public enum BattleTurn
    {
        None = 0,
        PlayerTurn,
        EnemyTurn,
        EndTurn
    }

    public class Battle
    {
        //What?

        public BattleTurn currTurn { get; set; }
    }

}
