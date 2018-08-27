
$(document).ready(function () {
	$('#txtSearchProdAssign').keypress(function (e) {
		var key = e.which;
		if (key == 13)  // the enter key code
		{
			$('input[name = butAssignProd]').click();
			return false;
		}
	});
})


