// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showImage(e) {
    var div = document.getElementById("materialImage");

    switch (Number(e.value)) {
        case 0:
            div.innerHTML = "<img src='https://images.thdstatic.com/productImages/ac750a8b-9590-40c4-80c7-8a28c08767c9/svn/weathered-fiberwood-natural-grain-formica-laminate-sheets-0891412ng408000-64_100.jpg' alt='laminate image' class='materialImage'/>";
            div.hidden = false;
            break;
        case 1:
            div.innerHTML = "<img src='https://mobileimages.lowes.com/productimages/066a1b5e-575c-4294-92e5-5196b87d007d/15357416.jpg?size=mthb' alt='Oak image' class='materialImage'/>";
            div.hidden = false;
            break;
        case 2:
            div.innerHTML = "<img src='https://a.1stdibscdn.com/elliptical-bolivian-rosewood-center-hall-or-dining-table-for-sale/1121189/f_161920821569050890595/16192082_master.jpg?disable=upscale&auto=webp&quality=60&width=60' alt='rosewood image' class='materialImage'/>";
            div.hidden = false;
            break;
        case 3:
            div.innerHTML = "<img src='https://www.ovisonline.com/GetImage.ashx?Path=%7e%2fAssets%2fProductImages%2fVeneerTech%2fStandard%2fOakWhitePlainSliced.jpg&maintainAspectRatio=true' alt='Veneer image' class='materialImage'/>";
            div.hidden = false;
            break;
        case 4:
            div.innerHTML = "<img src='https://thumbs.dreamstime.com/b/top-view-unfinished-pine-table-117065020.jpg' alt='Pine image' class='materialImage'/>";
            div.hidden = false;
            break;
        default:
            div.innerHTML = "";
            div.hidden = true;
            return;
    }

    
}