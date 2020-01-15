$(function() {

    $('#side-menu').metisMenu(); 
     //* Start Region for Category1 Table*
    $('#tbl_category1').dataTable({
        responsive: true
        
    });
    $("#chkcat1_all").click(function () { 
        $('#tbl_category1 tbody input[type="checkbox"]').prop('checked', this.checked);
    });
    //*End Region for Category1 Table*
    //* Start Region for Category2 Table*
    $('#tbl_category2').dataTable({
        responsive: true
    });
    $("#chkcat2_all").click(function () {
        $('#tbl_category2 tbody input[type="checkbox"]').prop('checked', this.checked);
    });
    //*End Region for Category2 Table*

    //* Start Region for Category3 Table*
    $('#tbl_category3').dataTable({
        responsive: true
    });
    $("#chkcat3_all").click(function () {
        $('#tbl_category3 tbody input[type="checkbox"]').prop('checked', this.checked);
    });
    //*End Region for Category3 Table*
    //* Start Region for Category3 Table*
    $('#tbl_product').dataTable({
       
    });
    
    $("#chkpro_all").click(function () {
        $('#tbl_product tbody input[type="checkbox"]').prop('checked', this.checked);
    });
    //*End Region for Category3 Table*

});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function() {
    $(window).bind("load resize", function() {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function() {
        return this.href == url || url.href.indexOf(this.href) == 0;
    }).addClass('active').parent().parent().addClass('in').parent();
    if (element.is('li')) {
        element.addClass('active');
    }
});
