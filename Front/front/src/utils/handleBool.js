export default function handleBool(status){

    let resultado = "";

    if(status == true){
        resultado = "On";
    }else{
        resultado = "Off";
    }

    return resultado;
}