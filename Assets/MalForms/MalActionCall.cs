//Any action call that appears in the UI
//Created by James Vanderhyde, 17 November 2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mal;
using TMPro;

public class MalActionCall : MalForm
{
    public override types.MalVal read_form()
    {
        types.MalList ml = new types.MalList();
        string functionName = this.galleryItemName;
        types.MalMap mm = new types.MalMap();
        for (int i=1; i<transform.childCount; i++)
        {
            Parameter p = transform.GetChild(i).GetComponentInChildren<Parameter>();
            types.MalKeyword k = types.MalKeyword.keyword(p.keyword);
            mm.assoc(k, transform.GetChild(i).GetComponentInChildren<MalForm>().read_form());
        }
        ml.cons(mm);
        ml.cons(new types.MalSymbol(functionName));

        types.MalList highlight = new types.MalList();
        highlight.cons(ml);
        highlight.cons(new types.MalObjectReference(this.gameObject)); //line of code to highlight
        highlight.cons(new Highlight());

        return highlight;
    }
}
