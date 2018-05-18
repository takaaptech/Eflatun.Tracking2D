﻿using System.Collections.Generic;
using starikcetin.UnityCommon.Expansions;
using starikcetin.UnityCommon.Utils.Calculation;
using starikcetin.UnityCommon.Utils.CodePatterns;
using UnityEngine;

namespace starikcetin.ManualTracking2D
{
    public class ConvexHullDatabase : GlobalSingleton<ConvexHullDatabase>
    {
        //prevent init
        protected ConvexHullDatabase()
        {
        }

        private readonly OrderedDictionary<GameObject, IList<Vector2>> _localConvexHullDictionary =
            new OrderedDictionary<GameObject, IList<Vector2>>();

        /// <summary>
        /// Gets the local convex hull of the given Prefab.
        /// </summary>
        public IList<Vector2> GetLocalConvexHull(GameObject prefab)
        {
            IList<Vector2> foundValue;
            if (_localConvexHullDictionary.TryGetValue(prefab, out foundValue))
            {
                return foundValue;
            }

            IList<Vector2> localConvexHull = prefab.GetComponent<SpriteRenderer>().sprite.vertices.MakeConvexHull();
            _localConvexHullDictionary.Add(prefab, localConvexHull);
            return localConvexHull;
        }
    }
}