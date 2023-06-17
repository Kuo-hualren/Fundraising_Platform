const convas = document.querySelector('canvas');
console.log(convas)

const c = convas.getContext('2d')

convas.width = innerWidth
convas.height = innerHeight

class Player {
    constructor(x, y, radius, color) {
        this.x = x
        this.y = y
        this.radius = radius
        this.color = color
    }

    draw() {
        c.beginPath()
        c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false)
        c.fillStyle = this.color
        c.fill()
    }
}

class Projectile {
    constructor(x, y, radius, color, velocity) {
        this.x = x
        this.y = y
        this.radius = radius
        this.color = color
        this.velocity = velocity
    }

    draw() {
        c.beginPath()
        c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false)
        c.fillStyle = this.color
        c.fill()
    }

    update() {
    	this.draw()
        this.x = this.x + this.velocity.x
        this.y = this.y + this.velocity.y
    }

}
class Enemy {
    constructor(x, y, radius, color, velocity) {
        this.x = x
        this.y = y
        this.radius = radius
        this.color = color
        this.velocity = velocity
    }

    draw() {
        c.beginPath()
        c.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false)
        c.fillStyle = this.color
        c.fill()
    }

    update() {
    	this.draw()
        this.x = this.x + this.velocity.x
        this.y = this.y + this.velocity.y
    }

}


const x = convas.width / 2
const y = convas.height / 2
const player = new Player(x, y, 15, "white")
player.draw()
// console.log(player)



const pros = []
const enemies = []

function spawnEnemies() {
	setInterval(() => {
		const x = Math.random()*convas.width
		const y = Math.random()*convas.height
		const radius = 20
		const color = `hsl(${Math.random()*360},50%,50%)`
		const angle = Math.atan2(
    		convas.height / 2 - y,
    		convas.width / 2 - x
    	)
	    const velocity = {
			x:Math.cos(angle),
			y:Math.sin(angle)
		}
		enemies.push(new Enemy(x,y,radius,color,velocity))
		console.log(enemies)
	}, 500)
	
}

let animationId
function animate() {
    animationId = requestAnimationFrame(animate)
    c.fillStyle = 'rgb(0,0,0,0.1)'
    c.fillRect(0,0,convas.width,convas.height)
    player.draw()
    pros.forEach((pro)=>{
		pro.update()
    })
    enemies.forEach((enemy, index) => {
    	enemy.update()

    	const dist = Math.hypot(player.x-enemy.x, player.y-enemy.y)
    	if (dist - player.radius - enemy.radius < 1) {
    		cancelAnimationFrame(animationId)
    	}

    	pros.forEach((projectile, proindex) => {
    		const dist = Math.hypot(projectile.x-enemy.x, projectile.y-enemy.y)
    		if (dist - projectile.radius - enemy.radius < 1){
    			setTimeout(() => {
    				enemies.splice(index, 1)
    				projectile.splice(proindex, 1)
    			}, 0)
    			
    		}
    		
    	})
    })
    
}



addEventListener("mousemove", (event) => {
    // console.log(event.clientX)
    const angle = Math.atan2(
    	event.clientY - convas.height / 2,
    	event.clientX - convas.width / 2
    	)
    const velocity = {
		x:Math.cos(angle) * 3,
		y:Math.sin(angle) * 3
	}
    pros.push(new Projectile(
    	convas.width / 2,
    	convas.height / 2,
    	5,
    	"white",
    	velocity
    	))
    console.log(angle)

})
spawnEnemies()
animate()