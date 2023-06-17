const convas = document.querySelector('canvas');
// console.log(convas)

const c = convas.getContext('2d')
console.log(c)
convas.width = innerWidth
convas.height = innerHeight

// ---------------------------
c.globalCompositeOperation = "destination-over"
let hue = Math.random()*360
let number = 0
let scale = 10
let size = 20;

function drawFlower() {
	let angle = number * 2
	let radius = scale*Math.sqrt(number)
	let x = radius*Math.sin(angle) + convas.width/2
	let y = radius*Math.cos(angle) + convas.height/2
	console.log(y)

	c.fillStyle = `hsl(${Math.random()*360},100%,50%)`
	// c.fillStyle = `hsl(`+ hue +`, 100%, 50%)`
	// c.fillStyle = 'green'
	// c.strokeStyle = 'blue'
	c.lineWidth = 5
	c.beginPath()
	c.arc(x ,y ,size ,0 , Math.PI * 2)
	c.closePath()
	c.fill()
	c.stroke()

	number+=2
}



function animate() {
	// size+=.5
	// c.clearRect(0,0,convas.width,convas.height)

	// x += 5*Math.sin(angle)
	// y += 5*Math.cos(angle)
	// angle+=0.09
	
	
	drawFlower()
	if (number >= 900) {return}
	requestAnimationFrame(animate)
}

animate()


addEventListener("mousedown", (event) => {
	// drawFlower()
	const angle = Math.atan2(
    	event.clientY - convas.height / 2,
    	event.clientX - convas.width / 2
    	)
	// console.log(angle)
})


// class Player {
//     constructor(x, y, radius, color) {
//         this.x = x
//         this.y = y
//         this.radius = radius
//         this.color = color
//     }

//     draw() {
//         c.beginPath()
//         c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false)
//         c.fillStyle = this.color
//         c.fill()
//     }

    
// }



// const pros = []

// const x = convas.width / 2
// const y = convas.height / 2
// console.log(x+"x"+y)
// const player = new Player(x, y, 20, "white")
// player.draw()


// function animatel() {
//     requestAnimationFrame(animatel)
//     c.fillStyle = 'rgb(0,0,0,0.1)'
//     c.fillRect(0,0,convas.width,convas.height)
//     player.draw()
  	
    
    
    
// }



// addEventListener("mousemove", (event) => {
    
//     console.log(event.clientX+","+event.clientY)
//     let p2 = new Player(event.clientX, event.clientY, 13, `hsl(${Math.random()*360},100%,50%)`)
//     function animates() {
// 	    requestAnimationFrame(animates)
	    
// 	  	p2.draw()

// 	}
    
//     animates()
	
   

// })

animatel()
