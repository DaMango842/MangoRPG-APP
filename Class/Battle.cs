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
