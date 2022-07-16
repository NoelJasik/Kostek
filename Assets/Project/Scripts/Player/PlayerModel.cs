using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/PlayerModel", order = 1)]
public class PlayerModel : ScriptableObject
{
    public List<Sprite> idleFrames;
        public List<Sprite> walkFrames;
            public List<Sprite> jumpFrames;
            public List<Sprite> rollFrames;
            public Sprite hitFrame;
            public Sprite deathFrame;
              //what the fuck am i doing in here, this is fucking spaghetti bolognese
            public float idleCounter;
            public float walkCounter;

            public float rollCounter;
             
            public int idleFrame;
            public int walkFrame;
            public int rollFrame;
            
            

        public void AnimateSprite(List<Sprite> _frames, SpriteRenderer _sr, float _timeBetweenFrames)
            {
                  if(_frames == idleFrames && idleCounter >= _timeBetweenFrames)
                  {
                      _sr.sprite = _frames[idleFrame];
                      idleFrame++;
                      if(idleFrame >= _frames.Count)
                      {
                        idleFrame = 0;
                      }
                      idleCounter = 0;
                  }
                        if(_frames == walkFrames && walkCounter >= _timeBetweenFrames)
                  {
                      _sr.sprite = _frames[walkFrame];
                      walkFrame++;
                      if(walkFrame >= _frames.Count)
                      {
                        walkFrame = 0;
                      }
                      walkCounter = 0;
                  }
                     if(_frames == rollFrames && rollCounter >= _timeBetweenFrames)
                  {
                      _sr.sprite = _frames[rollFrame];
                      rollFrame++;
                      if(rollFrame >= _frames.Count)
                      {
                        rollFrame = 0;
                      }
                      rollCounter = 0;
                  }
                  
            }
           
}
