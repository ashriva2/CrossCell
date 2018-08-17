function getSectionData()
{
    $("tr.item").each(function () {

        var id = $(this).attr("title");
        var email = $(this).val();

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