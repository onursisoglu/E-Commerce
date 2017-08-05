//-----------Sepet İşlemleri -------- //
//Tıklanan ürünü görselden sil 
function RemoveTr(ProductID) {   

        $("#tr-" + ProductID).fadeOut();
    };
// Ürün Silme başarılıysa Adeti kontrol et ve güncelle 
    function DeleteProduct(data) { 
        debugger
        if (data.length == 0) {

            $("#tabdiv").html('<div class="w3-margin text-center alert alert-danger">Sepetinizde Ürün Bulunmamaktadır... </div>');
            $("#shoppingComplete").hide();
        }
        var dataList = data;
        var totalprice = 0;
        var totalQuantity = dataList.length;
        for (var i = 0; i < dataList.length; i++) {

            totalprice += dataList[i].TotalPrice;
        }

        $("#toplam").html(totalprice + ",00 TL");

        $("#sayi").html(totalQuantity);
    };
    function Guncelle(value) {
        debugger
        $("#form" + value).submit();
    };
   //Ürün Adeti değiştirildiyse sepet adet görselini güncelle
    function yeniAdet(data) {
        debugger
        var list = data
        var totalPrice = 0;
        for (var i = 0; i < list.length; i++) {
            var s = list[i].ProductID
            var price = list[i].TotalPrice
            var totaldiv = $("#total-" + s)
            totaldiv.html(price + ",00 TL")

            totalPrice += data[i].TotalPrice;
        }

        $("#toplam").html(totalPrice + ",00 TL");

    };
//----------------------Arama İnputu Submit ve Sonuc--------------------------//

    function myfunction() {
        debugger
        var searchinput = $("#searchinput").val();
        if (searchinput == "") {
            return;
        }
        $("#subform").submit();

    };
    function result(data) {
        debugger
        document.getElementById("goster").innerHTML = null;
        if (data.length == 0) {
            document.getElementById("goster").style.display = "block";
            document.getElementById("goster").innerHTML = "<li><a><b>Aradığınız Ürün Bulunamadı</b></a></li>";
        }
        for (var i = 0; i < data.length; i++) {

            document.getElementById("goster").style.display = "block";
            document.getElementById("goster").innerHTML += "<li><a href='/Product/ProductDetail/" + data[i].ProductID + "?subcategoryID=" + data[i].SubCategoryID + "'>" + data[i].ProductName + "</a></li>";
            if (i == 10) {
                document.getElementById("goster").innerHTML += "<li class=\"divider\"></li> <li><a href=\"#\"><b> Tüm Sonuçlar İçin Tıklayın</b></a></li>";
                break;
            }
        }

    };
//-------Kullanıcı Bilgileri Ajax Dönüşü-------//
    function info(deger) {

        $("#partial").html(deger);
    };
//----------- Sepete Eklenme Mesajı ve Sepete Sayısı----------//
    function Calculate(data) {

        var dataList = data;
        if (data == false) {
            $("#hoop").html("Ürün Eklenemedi");
            $("#hoop").show(setTimeout(function () {
                $("#hoop").animate({ opacity: 0 }, 1500, function () {
                    $("#hoop").fadeOut();
                });
            })
            );

        }
        else {
            var ToplamAdet = dataList.length;
            //for (var i = 0; i < dataList.length; i++) {

            //    ToplamAdet += dataList[i].Quantity;
            //}
            $("#hoop").show();
            setTimeout(function () {
                $("#hoop").animate({ opacity: 0 }, 1500, function () {
                    $("#hoop").fadeOut();
                });
            });
        }

        $("#sayi").html(ToplamAdet);

    };
//------------ Ürünleri Azalan Artan Fiyata göre Sıralama-------//
    function SortResult(data) {
        debugger
        var a = data
        document.getElementById("sortdiv").innerHTML = null;
        document.getElementById("sortdiv").innerHTML = a;
    };
//----------- Favori ürün ekleme silme-------//
    function favorite(data) {
        debugger
        var a = data;
        if (data.IsActive == true) {
            $("#btn-" + data.ProductID).addClass("w3-text-red");
        }
        else {
            $("#btn-" + data.ProductID).removeClass("w3-text-red");
        }
    };
//--- ürün Detay favori ekleme Yazı Değiştirme----//
function detailFavorite(data) {
    debugger
    var a = data.ProductID;
    if (data.IsActive == true) {
        $("#btn").html("<i class='fa fa-heart w3-text-red'></i> Favori Ürününüz");

    }

    else {
        $("#btn").html("<i class='fa fa-heart'> </i>Favori Ürünlerime Ekle");
    }
};
//---- Yorum Ekleme------//
function resultComment(result) {
    if (result.url) {
        window.location.href = result.url;
    }
    else {
        document.getElementById("yorumcu").innerHTML += result
    }
}

//----- Ürün Detay Resim url Değiştirme-------//
function change(a) {
    debugger
    var b = document.getElementById("imgMain").setAttribute("src", a);
};
//-------- Silinen Adres -----//
function AddressDel(AddressID) {

    $("#" + AddressID).fadeOut();
};
//---- Adres Güncelleme Modal'na Veri Aktarma
function MoveData(id) {
    debugger

    var il = $("#btn-" + id).data('il');
    var ilce = $("#btn-" + id).data('ilce');
    var ulke = $("#btn-" + id).data('ulke');
    var adres = $("#btn-" + id).data('adres');
    var adresid = $("#btn-" + id).data('adresid');

    $("#City").val(il);
    $("#District").val(ilce);
    $("#Country").val(ulke);
    $("#Address1").val(adres);
    $("#hd").val(adresid);
}

