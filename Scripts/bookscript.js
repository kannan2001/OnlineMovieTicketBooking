function revme() {
    var textb = document.getElementById("Seatnumber");
    var str = textb.value;
    var str1 = "";

    l = str.length;
    for (i = l; i >= 0; --i) {
        str1 = str1 + str.substring(i, i + 1);
    }
    document.getElementById("results").innerHTML = str1;
}