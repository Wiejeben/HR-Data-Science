export default class DNA {
    public static randomChar(): string {
        let c = Math.floor(DNA.randomNumber(63, 122));
        if (c === 63) {
            c = 32;
        }
        if (c === 64) {
            c = 46;
        }

        return String.fromCharCode(c);
    }

    public static randomNumber(min: number, max: number): number {
        return (Math.random() * (max - min + 1)) + min;
    }

    public static Random(length: number): DNA {
        const genes = [];
        for (let i = 0; i < length; i++) {
            genes[i] = this.randomChar();
        }

        return new DNA(genes);
    }

    public genes: string[] = [];
    public fitness: number = 0;

    constructor(genes: string[]) {
        this.genes = genes;
    }

    public toString(): string {
        return this.genes.join('');
    }

    public calcFitness(target: string): void {
        let score = 0;
        for (let i = 0; i < this.genes.length; i++) {
            if (this.genes[i] === target.charAt(i)) {
                score++;
            }
        }

        // Use pow to make a change have a larger impact on the score
        this.fitness = Math.pow(score / target.length, 10);
    }

    /**
     * Mix two DNA objects.
     *
     * @param {DNA} partner
     * @return {DNA}
     */
    public crossover(partner: DNA): DNA {
        const genes = [];

        const midpoint = Math.floor(DNA.randomNumber(0, this.genes.length));

        // Half from one, half from the other
        for (let i = 0; i < this.genes.length; i++) {
            if (i > midpoint) {
                genes[i] = this.genes[i];
            } else {
                genes[i] = partner.genes[i];
            }
        }

        return new DNA(genes);
    }

    public mutate(rate: number): void {
        for (let i = 0; i < this.genes.length; i++) {
            if (Math.random() < rate) {
                this.genes[i] = DNA.randomChar();
            }
        }
    }
}