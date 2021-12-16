const { calculaReajuste, taxas } = require("./reajusta-salario");

const salario1 = 1500;
const result1 = salario1 + salario1 * taxas.taxa1;

const salario2 = 3500;
const result2 = salario2 + salario2 * taxas.taxa2;

const salario3 = 6500;
const result3 = salario3 + salario3 * taxas.taxa3;

test("salário de 1.500 terá taxa de 20%", () => {
  expect(calculaReajuste(salario1)).toBe(result1);
});

test("salário de 3.500 terá taxa de 15%", () => {
  expect(calculaReajuste(salario2)).toBe(result2);
});

test("salário de 6.500 terá taxa de 10%", () => {
  expect(calculaReajuste(salario3)).toBe(result3);
});
