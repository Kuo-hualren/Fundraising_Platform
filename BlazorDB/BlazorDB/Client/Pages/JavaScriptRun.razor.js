
export function createQRCode() {
    const QRContainer = document.getElementById("qrcode");
    QRContainer.innerHTML = "";
    const text = "https://www.youtube.com/watch?v=19eo39lqpLM";
    new QRCode(QRContainer, text);
}