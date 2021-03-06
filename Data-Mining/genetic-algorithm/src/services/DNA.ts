/**
 * Notes:
 * Genotype: How the data is stored (array of chars)
 * Phenotype: The expression of the data (visualisation) - (a string)
 */
export default class DNA {
    public static randomChar(): string {
        const allowedCharacters = ' abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*(),.?-_=+:"/<>';
        const i = Math.floor(DNA.randomNumber(0, allowedCharacters.length));
        return allowedCharacters[i];
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

    /**
     * Converts character array to a String.
     *
     * @return {string}
     */
    public getPhrase(): string {
        return this.genes.join('');
    }

    /**
     * Fitness function (Returns floating point % of "correct" characters)
     *
     * @param {string} target
     */
    public calcFitness(target: string): void {
        let score = 1;
        for (let i = 0; i < this.genes.length; i++) {
            if (this.genes[i] === target.charAt(i)) {
                score++;
            }
        }

        // Use pow to make a change have a larger impact on the score
        this.fitness = Math.pow(score / target.length, 50);
    }

    /**
     * Mix two DNA objects into a new one.
     *
     * @param {DNA} partner
     * @return {DNA}
     */
    public crossover(partner: DNA): DNA {
        const genes: string[] = [];

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

    /**
     * Based on a mutation probability, picks a new random character.
     *
     * @param {number} rate
     */
    public mutate(rate: number): void {
        for (let i = 0; i < this.genes.length; i++) {
            if (Math.random() < rate) {
                this.genes[i] = DNA.randomChar();
            }
        }
    }
}