/*******************************************************
******************** Values & Types ********************
********************************************************/

var a;  // "undefined""
typeof a;

a = "Hello World"; // "string""
typeof a;

a = 42; // "number"
typeof a;

a = true; // "boolean"
typeof a;

a = null; // "object" - this is actually a bug - should return null - won't be fixed
typeof a;

a = undefined; // "undefined"
typeof a;

a = { b: "c" }; // "object"
typeof a;

// six (seven in ES6) possible type-strings returned from typeof operator
// Remember: values are typed in JS, not variables - dynamic typing




/************************************************
******************** Objects ********************
*************************************************/

var obj = {
    a: "Hello, world!",
    b: 42,
    c: true
};

obj["a"];
obj["b"];
obj["c"];

obj.a;
obj.b;
obj.c;

/************************************************/

var obj = {
    a: "Hello, world!",
    b: 42,
};

var b = "a";
obj[b];
obj["b"];

/************************************************/

var arr = [
    "hello world",
    42,
    true
];

arr[0];
arr[1];
arr[2];

arr.length; // 3

arr.myNewProperty = 543; // An array is an object, so you can just randomly make up a new property for it!

typeof arr; // object - Arrays and functions are built-in types, specialized objects.

var arrObjHack = {
    0: "first string",
    1: "second string",
    2: "third string"
};

arrObjHack.length; // undefined

arrObjHack[1]; // "second string"
arrObjHack.1;   // Unexpected number exception

/************************************************/

function foo() {
    return 42;
}

foo.bar = "hello world"; // Remember, you can tack random properties onto any object dynamically! yay!?

typeof foo; // "function" - Function objects get their own types! So much for consistency!
typeof foo(); // "number" - Because it returns a number type - Think of it like it inlines the return type here.
typeof foo.bar; // "string" - Because this property is, in fact, a string!

// Remember: You can have properties on function objects (and all other objects, I assume). Bad idea.





/************************************************
************* Built-in Type Methods *************
*************************************************/

var a = "hello world",
    b = 3.14159;

a.length;
a.toUpperCase();    //Trivia: How does this work? H: String vs string
b.toFixed(4);

// Some primitive types have object wrappers - primitive types are automatically boxed when you call methods on them





/************************************************
**************** Comparing Values ***************
*************************************************/

var a = "42";
var b = Number(a);  // Explicit coercion

a;  // "42"
b;  // 42

/***********************************************/

var a = "42";
var b = a * 1;  // Implicit coercion

a;  // "42"
b;  // 42

/*
***Falsy***
""(empty string)
0, -0, NaN(invalid number)
null, undefined
false

***Truthy***
"hello"
42
true
[], [1, "2", 3] (arrays)
{ }, { a: 42 } (objects)
function foo() { .. } (functions)
*/

if (function () { })    // Ha. Nice.
    console.log(true);  // Logs it

/***********************************************/

// == checks for equality with coercion allowed
// === checks for equality without allowing coercion

var a = "42";
var b = 42;

a == b;
a === b;

// == and === only check for a reference match between objects (including arrays, functions)
// Find more info at http://www.ecma-international.org/ecma-262/5.1/#sec-11.9.3

var a = [1, 2, 3];
var b = [1, 2, 3];
var c = "1,2,3";

a == b; // False
a == c; // True
b == c; // True


/***********************************************/

var a = 41;
var b = "42";
var c = "43";

a < b;  // true
b < c;  // true

/***********************************************/

var a = 42;
var b = "foo";

a < b;  // false
a > b;  // false 
a == b; // false - tries to evaluate 42 == NaN

// b is coerced to NaN because it can't be coerced to any valid number






