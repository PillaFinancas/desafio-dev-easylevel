let taxas = [];

taxas["taxa1"] = 0.2;
taxas["taxa2"] = 0.15;
taxas["taxa3"] = 0.1;
taxas["taxa4"] = 0.05;

const calculaReajuste = (salario) => {
  const stringSalario = String(salario);

  /* remover tudo que não for numero */
  const replaceSalario = Number(stringSalario.replace(/[^\d]+/g, ""));

  if (salario >= 0.0 && salario <= 1999.99) {
    const reajuste = salario * taxas.taxa1;
    return salario + reajuste;
  } else if (salario >= 2000.0 && salario <= 3999.99) {
    const reajuste = salario * taxas.taxa2;
    return salario + reajuste;
  } else if (salario >= 4000.0 && salario <= 6999.99) {
    const reajuste = salario * taxas.taxa3;
    return salario + reajuste;
  } else if (salario >= 7000.0) {
    const reajuste = salario * taxas.taxa4;
    return salario + reajuste;
  }
};

const salario1 = 1500;
const result1 = salario1 + salario1 * taxas.taxa1;

const salario2 = 3500;
const result2 = salario2 + salario2 * taxas.taxa2;

const salario3 = 6500;
const result3 = salario3 + salario3 * taxas.taxa3;

console.log(calculaReajuste(salario1), result1);
console.log(calculaReajuste(salario2), result2);
console.log(calculaReajuste(salario3), result3);
module.exports = { calculaReajuste, taxas };
