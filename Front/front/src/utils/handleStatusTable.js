export default function handleBool(status){
    
    let resultado = "";

    if(status === "On"){
        resultado = true;
    }else if(status === "Off"){
        resultado = false;
    }

    return resultado;
}