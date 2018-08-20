function getSectionData()
{
    $("tr.item").each(function (i, row) {

        var $row = $(row),

        var obj = new Object();
        obj.questions = $(this).attr("title");
        obj.comments = $(this).attr("title");
        obj.level = $(this).attr("title");
        obj.weight = $(this).attr("title");
        obj.answers = $(this).attr("title");
        obj.score = $(this).attr("title");
        obj.max = $(this).attr("title");
        obj.max_score = $(this).attr("title");
        

        item = {}
        item["title"] = id;
        item["email"] = email;
        

        //$("tr.item").each(function () {
        //    var quantity1 = $(this).find("input.name").val(),
        //        quantity2 = $(this).find("input.id").val();
        //    console.log(quantity1);
        //    console.log(quantity2);
        //});

        jsonObj.push(item);
    });


}