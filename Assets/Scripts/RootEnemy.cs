using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootEnemy : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private PolygonCollider2D polygonCollider;

    void Awake(){
        _renderer = this.GetComponent<SpriteRenderer>();
        //polygonCollider = this.GetComponent<PolygonCollider2D>();
    }

    void Update(){
        // stretch renderer height by time
        _renderer.size = new Vector2(_renderer.size.x, _renderer.size.y + 0.01f);

        // update collider
        /*
        var sprite = _renderer.sprite;
        for (int i = 0; i < polygonCollider.pathCount; i++) 
            polygonCollider.SetPath(i, new Vector2[0]);

        polygonCollider.pathCount = sprite.GetPhysicsShapeCount();
        
        List<Vector2> path = new List<Vector2>();
        for (int i = 0; i < polygonCollider.pathCount; i++) {
            path.Clear();
            sprite.GetPhysicsShape(i, path);
            polygonCollider.SetPath(i, path);
        }   
        */
    }
}
