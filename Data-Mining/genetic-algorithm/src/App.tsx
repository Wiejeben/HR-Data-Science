import * as React from 'react';
import styled from 'styled-components';
import Population from "./services/Population";
import DNA from "./services/DNA";

interface IAppState {
    bestPhrase: string;
    population: DNA[];
    averageFitness: number;
    totalGenerations: number;
    totalExecutionTime: number;
    fastForward: boolean;
}

export default class App extends React.Component<any, IAppState> {
    protected targetPhrase: string = 'To be or not to be.';
    protected mutationRate: number = 0.05;
    protected maxPopulation: number = 100;
    protected population: Population;

    constructor(props: any) {
        super(props);
        this.evolve = this.evolve.bind(this);
        this.restart = this.restart.bind(this);
        this.toggleFastForward = this.toggleFastForward.bind(this);

        this.state = {
            ...this.init(),
        };
    }

    /**
     * Initialize a new population and reset state.
     *
     * @return {IAppState}
     */
    public init(): IAppState {
        this.population = new Population(this.targetPhrase, this.mutationRate, this.maxPopulation);

        this.population.calcFitness();
        return {
            ...this.getPopulationStatistics(),
            totalExecutionTime: 0,
            fastForward: false,
        };
    }

    /**
     * Get most up to date population statistics.
     * @return {IAppState}
     */
    public getPopulationStatistics() {
        return {
            bestPhrase: this.population.best().getPhrase(),
            population: this.population.getPopulation(),
            averageFitness: this.population.averageFitness(),
            totalGenerations: this.population.getGeneration(),
        };
    }

    /**
     * Evolve population into the next generation.
     */
    public evolve(): void {
        const start = performance.now();
        // Prepare mating pool
        this.population.naturalSelection();

        // Generate new population
        this.population.generate();

        // Calculate fitness
        this.population.calcFitness();
        const end = performance.now();

        this.setState({
            ...this.getPopulationStatistics(),
            totalExecutionTime: this.state.totalExecutionTime + (end - start)
        });

        // Generate next generation if we haven't solved the problem.
        if (this.population.best().getPhrase() !== this.targetPhrase) {
            // Skip waiting for animation frames
            if (this.state.fastForward) {
                this.evolve();
                return;
            }

            window.requestAnimationFrame(this.evolve)
        }
    }

    public toggleFastForward() {
        this.setState({fastForward: !this.state.fastForward});
    }

    /**
     * Reset population.
     */
    public restart() {
        this.setState({...this.init()});
    }

    public render() {
        return (
            <Wrapper>
                <Column>
                    <Title>Target phrase: {this.targetPhrase}</Title>
                    <Title>Best phrase: {this.state.bestPhrase}</Title>

                    <div>
                        <p>
                            total generations: {this.state.totalGenerations}<br/>
                            average fitness: {(this.state.averageFitness * 100).toFixed(2)}<br/>
                            total population: {this.maxPopulation}<br/>
                            mutation rate: {this.mutationRate * 100}%<br/>
                            average execution
                            time: {(this.state.totalGenerations > 0) ? (this.state.totalExecutionTime / this.state.totalGenerations).toFixed(2) : 0}ms<br/>
                        </p>
                        <h3>Options</h3>
                        <button onClick={this.evolve}>Start evolving</button><br />
                        <label><input type="checkbox" checked={this.state.fastForward} onChange={this.toggleFastForward} /> fast forward</label><br />
                        <button onClick={this.restart}>Restart</button>
                    </div>
                </Column>
                {this.targetPhrase.length < 50 && this.maxPopulation < 200 ?
                    <Column>
                        <ul>
                            {this.state.population.map((value, key) => <li key={key}>{value.getPhrase()}</li>)}
                        </ul>
                    </Column>
                    : ''}

            </Wrapper>
        );
    }
}

const Wrapper = styled.div`
    margin: 0 auto;
    max-width: 1000px;
    display: flex;
    flex-direction: row;
    justify-content: space-between
`;

const Title = styled.h1``;

const Column = styled.section``;