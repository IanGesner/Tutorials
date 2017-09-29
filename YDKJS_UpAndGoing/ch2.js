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
arrObjHack.1;   // Unexpected number exception - properties must be valid identifiers - identifiers must match [a-z]|[A-Z]|[_]|[$] + [same including 0-9]*

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





/************************************************
**************** Comparing Values ***************
*************************************************/

var a = 2;

foo();  // Hoisted - okay

function foo() {
    a = 3;

    console.log(a); // 3

    var a;  // Hoisted - not okay
}

console.log(a); // 2

// Hoisted to top of scope

/***********************************************/

function foo() {
    var a = 1;

    function bar() {
        var b = 2;

        function baz() {
            var c = 3;

            console.log(a, b, c); // 1 2 3
        }

        baz();
        console.log(a, b);
    }

    bar();
    console.log(a);
}

foo();

// Output: 123, 12, 1

/***********************************************/

function foo() {
    var a = 1;

    function bar() {
        var b = 2;

        function baz() {
            var c = 3;

            console.log(a, b, c); // 1 2 3
        }

        console.log(a, b);
        baz();
    }

    console.log(a);
    bar();
}

foo();

//Output: 1, 12, 123

/***********************************************/

function foo() {
    a = 1;  // Creates a global variable whe not in strict mode
}

foo();
a;  // 1

/***********************************************/

function foo() {
    var a = 1;

    if (a >= 1) {
        let b = 2;  // b only exists in teh scope of the if statement

        while (b < 5) {
            let c = b * 2;  // c only exists in the scope of the while loop
            b++;

            console.log(a + c);
        }
    }
}





/************************************************
****************** Conditionals *****************
*************************************************/

switch (a) {
    case 2: // falls through to case 10
    case 10:
        // some cool stuff
        break;
    case 42:
        // other stuff
        break;
    default:
    // fallback
}

/***********************************************/

var a = 42;
var b = (a > 41) ? "hello" : "world";
b;





/************************************************
****************** Strict Mode ******************
*************************************************/

function foo() {
    "use strict";

    function bar() {
        //  strict mode here
    }
    //  strict mode here
}

//  no strict mode here

//  One key benefit: No more automatic global vars






/************************************************
****************** Strict Mode ******************
*************************************************/

function foo() {
    //  foo is basically just a variable referencing a function value
    console.log(42);
}

var bar = foo;  // bar === foo

/***********************************************/

var foo = function () { // anonymous function
    console.log(42);    // same thing minus a reference to the function
}

/***********************************************/

var bar = function foo() {
    console.log(42);    // all the same
}

/***********************************************/

    (function IIFE() {
        console.log("Hello!");
    })();   // Just like with normal function references, the () executes the function

var x = (function IIFE() {
    return 42;
})();

var x = (function () {  //Can have an anonymous function here too
    return 42;
})();

IIFE(); //Can't do this

/***********************************************/

function makeAdder(x) {

    function add(y) {   // Because add() uses makeAdder's inner x variable, it is said that it has a "closure" over it
        return y + x;
    }

    return add;
}

var plusThirteen = makeAdder(13);   // plusThirteen now represents the inner function "add()" with x 13
plusThirteen(3);                    // add(3) where x = 13
// NICE

/***********************************************/

function User() {
    var username, password;

    function doLogin(user, pw) {
        username = user;    // Notice the arguments are assigned to User() scope variables
        password = pw;      // this allows other publicAPI functions to use them, just like a private field
                            
        if (user === "pandaBear55" && pw === "password")
            return "Congratulations, You have logged in using Ian's Super-Secure Authentication System!";
        else
            return "Authentication Failed!";
    }

    var publicAPI = {  // We have hacky objects! Yes!!! 
        login: doLogin
    };

    return publicAPI;
}

var user = User();
user.login("pandaBear55", "password");
user.login("leroyJenkins99", "wookie343");

/***********************************************/

function foo() {
    console.log(this.bar);  // this usually refers to an object - NOT THE CALLING FUNCTION
}

var bar = "global";

var obj1 = {
    bar: "obj1",
    foo: foo
};

var obj2 = {
    bar: "obj2"
};

foo();  // "global"
obj1.foo() // "obj1"
foo.call(obj2) // "obj2"
new foo(); // undefined





/************************************************
****************** Prototypes *******************
*************************************************/

var foo = {
    a: 42
};

var bar = Object.create(foo);

bar.b = 3;

bar.b;
bar.a;  // falls back on property a - kind of like b derives from a
        // ... but he says not to use it like inheritance
        // ... for use with behavior delegation pattern







/************************************************
******************* Old & new *******************
*************************************************/

if (!Number.isNaN) {    // Number.isNaN will be undefined if it doesn't already exist - undefined is in the "falsy" list
    Number.isNaN = function isNaN(x) {
        return x !== x; // NaN is not identically equal to NaN, but anything other value of x make this statement evaluate false
    }
}

// ES6-Shim is a popular polyfill - but transpiling sounds better tbh

function foo(a = 2) {   // ES6 ++default arguments
    console.log(a);
}

// Will be transpiled as:

function foo() {
    var a = arguments[0] !== (void 0) ? arguments[0] : 2;   // void 0 === undefined
    console.log(a);
}

// Babel and Traceur are the most common transpilers






/************************************************
******************* Old & new *******************
*************************************************/

// document is a "host object"

// getElementById(..) is an interface to a built-in DOM method from the browser.


/************************************************
******************* Into YDKYS ******************
*************************************************/

// Info about the next few books
// Scopes & Closures - necessary - read 1st
// this & Object Prototypes - necessary - read 2nd
// Types & Grammar - not as useful - read when convenient
// Async & Performance - sounds awesome - read 3rd
// ES6 & Beyond - read this or types & grammar last, w/e
