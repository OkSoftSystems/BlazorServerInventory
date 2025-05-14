function bM(d, r) {
    d.addEventListener("close", async e => {
        await r.invokeMethodAsync("MA", d.returnValue);
    });
}
function bOM(d) {
    if (!d.open) {
        d.showModal();
    }
}
function bCM(d) {
    if (d.open) {
        d.close();
    }
}
window.sD = function () {
    document.getElementById('cD').showModal();
}