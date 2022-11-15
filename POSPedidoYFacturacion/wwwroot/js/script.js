function imprimir()
{
    window.print();
}

function OpenNewPage(url)
{
    return new Promise((resolve) => {
    var newwindow = window.open(url);
    newwindow.focus();
    resolve();
    });
}

function ClosePage()
{
    return new Promise((resolve) => {
    window.close();
    resolve();
    });
}


function optionsdialog(titulo, mostrarcancelar, mostrardenegar, textoconfirmar, textodenegar)
{
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            showDenyButton: mostrardenegar,
            showCancelButton: mostrarcancelar,
            confirmButtonText: textoconfirmar,
            denyButtonText: textodenegar,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                resolve(1)
            } else if (result.isDenied) {
                resolve(2)
            } else {
                resolve(0)
            }
        })
    });
}

function ConfirmarDialog(titulo, textoconfirmar, textodenegar)
{
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            showDenyButton: true,
            showCancelButton: false,
            confirmButtonText: textoconfirmar,
            denyButtonText: textodenegar,
          }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
              resolve(true)
            } else if (result.isDenied) {
              resolve(false)
            }
          })
    });
}

