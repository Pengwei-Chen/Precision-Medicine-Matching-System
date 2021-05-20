$(function () {
	$("div.navbar-collapse>div.nav-line").stop();
	var url = location.href;
	var page = 0;
	if (url.indexOf("/Matching") != -1) {
		page = 1;
	}
	else if (url.indexOf("/KnowledgeBase") != -1 || url.indexOf("/DrugLabelAnnotations") != -1 || url.indexOf("/ClinicalGuidelineAnnotations") != -1 || url.indexOf("/AnnotatedDrugs") != -1) {
		page = 2
	}
	else if (url.indexOf("/AboutUs") != -1) {
		page = 3;
	}
	$("div.navbar-collapse>div.nav-line").css({
		'left': $("div.navbar-collapse>ul.navbar-nav>li.nav-item").eq(page).position().left,
		'width': $("div.navbar-collapse>ul.navbar-nav>li.nav-item").eq(page).outerWidth()
	});
	document.getElementsByClassName("nav-line")[0].style.visibility = "visible";
})

$("div.navbar-collapse>ul.navbar-nav>li.nav-item").hover(function () {
	$("div.navbar-collapse>div.nav-line").stop().animate({
		left: $(this).position().left,
		width: $(this).outerWidth()
	}, 300);
})

$("div.navbar-collapse>ul.navbar-nav>li.nav-item").mouseleave(function () {
	var url = location.href;
	var page = 0;
	if (url.indexOf("/Matching") != -1) {
		page = 1;
	}
	else if (url.indexOf("/KnowledgeBase") != -1 || url.indexOf("/DrugLabelAnnotations") != -1 || url.indexOf("/ClinicalGuidelineAnnotations") != -1 || url.indexOf("/AnnotatedDrugs") != -1) {
		page = 2
	}
	else if (url.indexOf("/AboutUs") != -1) {
		page = 3;
	}
	$("div.navbar-collapse>div.nav-line").stop().animate({
		'left': $("div.navbar-collapse>ul.navbar-nav>li.nav-item").eq(page).position().left,
		'width': $("div.navbar-collapse>ul.navbar-nav>li.nav-item").eq(page).outerWidth()
	}, 300);
})