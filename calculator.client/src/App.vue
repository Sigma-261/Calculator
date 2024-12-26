<template>
  <div id="app">
    <h1 class="title">GeeksForGeeks</h1>
    <h2>Calculator App</h2>
    <div class="calculator">
      <input type="text" class="result"
             :value="result" readonly />
      <div class="buttons">
        <button class="number"
                @click="handleClick('7')">
          7
        </button>
        <button class="number"
                @click="handleClick('8')">
          8
        </button>
        <button class="number"
                @click="handleClick('9')">
          9
        </button>
        <button class="operator"
                @click="handleOperatorClick('/')">
          /
        </button>

        <button class="number"
                @click="handleClick('4')">
          4
        </button>
        <button class="number"
                @click="handleClick('5')">
          5
        </button>
        <button class="number"
                @click="handleClick('6')">
          6
        </button>
        <button class="operator"
                @click="handleOperatorClick('*')">
          *
        </button>

        <button class="number"
                @click="handleClick('1')">
          1
        </button>
        <button class="number"
                @click="handleClick('2')">
          2
        </button>
        <button class="number"
                @click="handleClick('3')">
          3
        </button>
        <button class="operator"
                @click="handleOperatorClick('-')">
          -
        </button>

        <button class="number"
                @click="handleClick('0')">
          0
        </button>
        <button class="number"
                @click="handleClick('.')">
          .
        </button>
        <button class="number"
                @click="handleClick('00')">
          00
        </button>

        <button class="operator"
                @click="handleOperatorClick('+')">
          +
        </button>

        <button class="clear"
                @click="handleClear">
          C
        </button>
        <button class="clear"
                @click="handleClearEntry">
          CE
        </button>
        <button class="equal"
                @click="calculate()">
          =
        </button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'App',
    data() {
      return {
        result: '',
        calculated: false
        // Flag to track if calculation has been done
      };
    },
    methods: {
      handleClick(value) {
        if (this.calculated) {
          // If calculation has been done,
          // start a new expression
          this.result = value;
          this.calculated = false; // Reset flag
        } else {
          this.result += value;
        }
      },
      handleClear() {
        this.result = '';
        this.calculated = false; // Reset flag
      },
      handleClearEntry() {
        if (this.result && this.result.length > 0) {
          this.result = this.result.slice(0, -1);
          if (this.result.length === 0) {
            this.handleClear();
          }
        } else {
          this.handleClear();
        }
      },
      handleOperatorClick(operator) {
        // If the last character is an operator,
        // replace it with the new operator
        if (/[+*/-]$/.test(this.result)) {
          this.result = this.result.slice(0, -1) + operator;
        } else {
          // Otherwise, add the new operator
          this.result += operator;
        }
        this.calculated = false; // Reset flag
      },
      calculate() {
        try {
          let evaluatedResult = eval(this.result.
            replace(/(^|[^0-9])0+(\d+)/g, '$1$2'));
          if (evaluatedResult === Infinity ||
            evaluatedResult === -Infinity) {
            throw new Error('Divide by zero error');
          }
          this.result = Number.isFinite(evaluatedResult)
            ? evaluatedResult : 'Error';
          this.calculated = true;
          // Set flag to true after calculation
        } catch (error) {
          if (error.message === 'Divide by zero error') {
            this.result = 'Error: Divide by zero';
          } else {
            this.result = 'Error';
          }
        }
      }
    }
  };
</script>

<style src="./src/assets/main.css">
  /* Add your styles here */
</style>
