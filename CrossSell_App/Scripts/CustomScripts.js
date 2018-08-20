$("#save_objective").click(function () 
{
    alert("I am in custom script");
    $("tr.objective_data").find('td').each(function (i) {

        //var $row = $(row),
  
        console.log($(this).text());
                //var obj = new Object();
        //obj.questions = $(this).find("input.name").val();
        //obj.comments = $(this).find("input.name").val();
        //obj.level = $(this).find("input.name").val();
        //obj.weight = $(this).find("input.name").val();
        //obj.answers = $(this).find("input.name").val();
        //obj.score = $(this).find("input.name").val();
        //obj.max = $(this).find("input.name").val();
        //obj.max_score = $(this).find("input.name").val();

        

        //item = {}
        //item["title"] = id;
        //item["email"] = email;
        

        //$("tr.item").each(function () {
        //    var quantity1 = $(this).find("input.name").val(),
        //        quantity2 = $(this).find("input.id").val();
        //    console.log(quantity1);
        //    console.log(quantity2);
        //});

        jsonObj.push(item);
    });


})