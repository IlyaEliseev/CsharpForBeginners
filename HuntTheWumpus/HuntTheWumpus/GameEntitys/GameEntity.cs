
namespace HuntTheWumpus.GameEntitys
{
    public abstract class GameEntity
    {
        public Coordinates Coordinates { get; set; }
        
        public string GameEntityModel{ get; set; }

        public virtual void GetVoice()
        {

        }
        
        public GameEntity(Coordinates coordinates, string gameEntityModel)
        {
            Coordinates = coordinates;
            GameEntityModel = gameEntityModel;            
        }
        public GameEntity(Coordinates coordinates)
        {
            Coordinates = coordinates;            
        }
    }
}
