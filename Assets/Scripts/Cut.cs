using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
   public Transform left;
   public Transform right;
   List<SpriteSlicer2DSliceInfo> m_SlicedSpriteInfo = new List<SpriteSlicer2DSliceInfo>();

   public void OnCut()
   {
        SpriteSlicer2D.SliceAllSprites(left.transform.position, right.transform.position, true, ref m_SlicedSpriteInfo);

        if(m_SlicedSpriteInfo.Count > 0){
            for(int spriteIndex = 0; spriteIndex < m_SlicedSpriteInfo.Count; spriteIndex++){
                for(int childSprite = 0; childSprite < m_SlicedSpriteInfo[spriteIndex].ChildObjects.Count; childSprite++)
                {
                    var rigidBody = m_SlicedSpriteInfo[spriteIndex].ChildObjects[childSprite].GetComponent<Rigidbody2D>();
                    rigidBody.gameObject.AddComponent<FadeAndDestroy>();

                    Vector2 sliceDirection = right.transform.position - left.transform.position;
                    sliceDirection.Normalize();
                    rigidBody.AddForce(sliceDirection * 500.0f);
                }
            }
        }

        // destroy self after cut after 3 sec
        Destroy(gameObject, 3f);
   }

   public void Update(){
         if(Input.GetKeyDown(KeyCode.Space)){
              OnCut();
         }
   }
}
