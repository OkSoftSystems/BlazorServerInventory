window.printToPdf = (elementId, fileName) => {
    const element = document.getElementById(elementId);
    html2pdf().set({
        margin: 0.5,
        filename: fileName,
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    }).from(element).save();
};

// Print section of the page
window.printPage = function (elementId) {
    const content = document.getElementById(elementId).innerHTML;
    const printWindow = window.open('', '_blank', 'width=800,height=600');

    printWindow.document.write(`
        <html>
            <head>
                <title>Print</title>
                <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
                <style>
                    body { font-family: Arial, sans-serif; padding: 20px; }
                    table { width: 100%; border-collapse: collapse; }
                    th, td { padding: 8px; text-align: left; border: 1px solid #ccc; }
                </style>
            </head>
            <body onload="window.print(); window.close();">
                ${content}
            </body>
        </html>
    `);

    printWindow.document.close();
};

//// Alternative Print section of the page
//window.printPage = function (elementId) {
//    const originalContent = document.body.innerHTML;
//    const printContent = document.getElementById(elementId).innerHTML;
//    document.body.innerHTML = printContent;
//    window.print();
//    document.body.innerHTML = originalContent;
//};