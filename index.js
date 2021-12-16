let salario = Number(prompt("Digite o seu salário. (Ex: 1999)"))

if(salario <= 1999){
    let calculoAjuste = salario / 100 * 20;
    const ajusteFinal = salario + calculoAjuste;

    alert(`Seu salário recebeu um ajuste e agora é ${ajusteFinal}`)

}else if( salario >= 2000 || salario <= 3999){
    let calculoAjuste = salario / 100 * 15;
    const ajusteFinal = salario + calculoAjuste;

    alert(`Seu salário recebeu um ajuste e agora é ${ajusteFinal}`)

}else if(salario >= 4000 || salario <= 6999){
    let calculoAjuste = salario / 100 * 10;
    const ajusteFinal = salario + calculoAjuste;

    alert(`Seu salário recebeu um ajuste e agora é ${ajusteFinal}`)

}else if(salario > 7000){
    let calculoAjuste = salario / 100 * 5;
    const ajusteFinal = salario + calculoAjuste;

    alert(`Seu salário recebeu um ajuste e agora é ${ajusteFinal}`)

}else{
    alert("Valor invalido")
}