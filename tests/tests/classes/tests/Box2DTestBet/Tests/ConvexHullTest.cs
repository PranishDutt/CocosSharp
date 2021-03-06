using System.Collections.Generic;
using FarseerPhysics.Common;
using FarseerPhysics.Common.ConvexHull;
using FarseerPhysics.TestBed.Framework;
using Microsoft.Xna.Framework;
using CocosSharp;

namespace FarseerPhysics.TestBed.Tests
{
    public class ConvexHullTest : Test
    {
        private Vertices _chainHull;
        private Vertices _giftWrap;
        private Vertices _melkman;
        private Vertices _pointCloud1;
        private Vertices _pointCloud2;
        private Vertices _pointCloud3;

        private ConvexHullTest()
        {
            _pointCloud1 = new Vertices(32);

            for (int i = 0; i < 32; i++)
            {
                float x = Rand.RandomFloat(-10, 10);
                float y = Rand.RandomFloat(-10, 10);

                _pointCloud1.Add(new Vector2(x, y));
            }

            _pointCloud2 = new Vertices(_pointCloud1);
            _pointCloud3 = new Vertices(_pointCloud1);

            //Melkman DOES NOT work on point clouds. It only works on simple polygons.
            _pointCloud1.Translate(new Vector2(-20, 30));
            _melkman = Melkman.GetConvexHull(_pointCloud1);

            //Giftwrap works on point clouds

            _pointCloud2.Translate(new Vector2(20, 30));
            _giftWrap = GiftWrap.GetConvexHull(_pointCloud2);

            _pointCloud3.Translate(new Vector2(20, 10));
            _chainHull = ChainHull.GetConvexHull(_pointCloud3);
        }

        public override void Update(GameSettings settings, GameTime gameTime)
        {
            DebugView.DrawString(50, TextLine, "Melkman: Red");
            TextLine += 15;
            DebugView.DrawString(50, TextLine, "Giftwrap: Green");
            TextLine += 15;
            DebugView.DrawString(50, TextLine, "ChainHull: Blue");
            TextLine += 15;

            DebugView.BeginCustomDraw();
            for (int i = 0; i < 32; i++)
            {
                DebugView.DrawPoint(_pointCloud1[i], 0.1f, Color.Yellow);
                DebugView.DrawPoint(_pointCloud2[i], 0.1f, Color.Yellow);
                DebugView.DrawPoint(_pointCloud3[i], 0.1f, Color.Yellow);
            }

            var vector2List = new List<CCVector2>();
            foreach (var v in _melkman)
                vector2List.Add((CCVector2)v);

			DebugView.DrawPolygon(vector2List.ToArray(), _melkman.Count, Color.Red);

            vector2List.Clear();
            foreach (var v in _giftWrap)
                vector2List.Add((CCVector2)v);
            DebugView.DrawPolygon(vector2List.ToArray(), _giftWrap.Count, Color.Green);

            vector2List.Clear();
            foreach (var v in _chainHull)
                vector2List.Add((CCVector2)v);

            DebugView.DrawPolygon(vector2List.ToArray(), _chainHull.Count, Color.Blue);
            DebugView.EndCustomDraw();

            base.Update(settings, gameTime);
        }

        internal static Test Create()
        {
            return new ConvexHullTest();
        }
    }
}