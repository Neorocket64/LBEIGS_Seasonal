using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unknown : PlayChara {

    protected override void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
    }
}
